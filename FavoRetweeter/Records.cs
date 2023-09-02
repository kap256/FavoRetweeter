
using System;
using System.Collections.Generic;
using System.IO;
using MstStatus = Mastonet.Entities.Status;
using System.Linq;

namespace FavoRetweeter
{
    public class Record
    {
        public enum Type
        {
            Mastodon,
            Misskey
        }
        public readonly Type RecordType;
        public readonly string ID;
        public readonly long Tick;


        public Record()
        {
        }
        public Record(MstStatus status)
            :this(status.Id,Type.Mastodon)
        {
        }
        public Record(string id, Type type)
            : this(id, type, DateTime.Now.Ticks)
        {
        }
        public Record(string id, Type type,long tick)
        {
            RecordType = type;
            ID = id;
            Tick = tick;
        }
        public Record(string str)
        {
            var parts = str.Split(',').ToList();
            for (int i = parts.Count; i < 3; i++) {
                parts.Add("");
            }

            Enum.TryParse<Type>(parts[0], out RecordType);
            long.TryParse(parts[1], out Tick);
            ID = parts[2];

            if (String.IsNullOrEmpty(ID)) {
                ID = null;
            }
        }

        public new string ToString()
        {
            return $"{RecordType.ToString()},{Tick},{ID}";
        }

    }

    public static class Records
    {
        public static string FILE_NAME => "FRT_Record.log";

        private static readonly Dictionary<string, Record> MastodonDic = new();
        private static readonly Dictionary<string, Record> MisskeyDic = new();
        private static bool Saved = false;
        private static DateTime SavedTime = DateTime.MinValue;


        public static void Load(bool append=false)
        {
            if (!File.Exists(FILE_NAME)) {
                return;
            }

            if (!append) {
                MastodonDic.Clear();
                MisskeyDic.Clear();
            } else {
                if (File.GetLastWriteTime(FILE_NAME) < SavedTime) {
                    return;
                }
            }

            //最古設定の上限値から、さらに2日ぐらい余裕を持って記録を消す。
            long delete_day = DateTime.Now.AddDays(-(Config.BackTweetOldestDay.Max + 2)).Ticks;
            using (var reader = new StreamReader(FILE_NAME)) {
                try {
                    while (true) {
                        var line = reader.ReadLine();
                        if (line == null) break;

                        var rec = new Record(line);
                        if (rec.Tick >= delete_day) {
                            Insert(rec);
                        }
                    }
                } catch (Exception) {
                    throw;
                }
            }
            Saved = true;
            SavedTime = File.GetLastWriteTime(FILE_NAME);
        }

        public static bool Save()
        {
            if (Saved) {
                return false;
            }
            if (File.GetLastWriteTime(FILE_NAME) > SavedTime) {
                Load(true);
            }
            using (var writer = new StreamWriter(FILE_NAME)) {
                foreach (var record in MastodonDic.Values) {
                    writer.WriteLine(record.ToString());
                }
                foreach (var record in MisskeyDic.Values) {
                    writer.WriteLine(record.ToString());
                }
            }
            Saved = true;
            SavedTime = File.GetLastWriteTime(FILE_NAME);

            return true;
        }

        public static bool SaveAppend(IEnumerable<Record> records)
        {
            using (var writer = new StreamWriter(FILE_NAME,true)) {
                foreach (var record in records) {
                    if (record != null) {
                        writer.WriteLine(record.ToString());
                    }
                }
            }
            return true;
        }

        public static Record MstFind(string id)
        {
            Record ret;
            if (MastodonDic.TryGetValue(id, out ret)) {
                return ret;
            }
            return null;
        }
        public static Record MskFind(string id)
        {
            Record ret;
            if (MisskeyDic.TryGetValue(id, out ret)) {
                return ret;
            }
            return null;
        }
        public static void Insert(Record record)
        {
            if (record == null) return;
            //set時の重複は上書きになるので、雑に書き足せばappendになるハズ。
            switch (record.RecordType) {
                case Record.Type.Mastodon:
                    MastodonDic[record.ID] = record;
                    break;
                case Record.Type.Misskey:
                    MisskeyDic[record.ID] = record;
                    break;
            }

            Saved = false;
        }
    }
}
