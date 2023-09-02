namespace MSTest
{
    [TestClass]
    public class UnitTest
    {
        static TestContext Context;

        [ClassInitialize]
        public static void ClassInitialize(TestContext t)
        {
            Context = t;
        }

        /// <summary>
        /// Usage記載の内容をテスト
        /// 
        /// ※2023年現在、
        /// 　「SecretKey」に相当しそうな項目が見つからないので、
        /// 　仕様変更で動作しなくなった可能性がある。
        /// 　https://misskey-hub.net/docs/api
        /// </summary>
        [TestMethod]
        [Ignore]
        public async Task Usage()
        {
            // Create your app instance
            var app = new Misq.App(
                TestData.Host(),
                TestData.SecretKey());

            // Authorize user
            var user = await app.Authorize();

            // Let's post a message to Misskey
            await user.Request(
                "notes/create",
                new Dictionary<string, object> {
                    { "text", "yee haw!" }
            });
        }

        /// <summary>
        /// 基本の接続
        /// </summary>
        [TestMethod]
        public async Task Ping()
        {
            var user = new Misq.Me(TestData.Host(), TestData.AccessToken());

            var api = new Misq.Wrapper.API(user);

            var result = await api.Ping();

            Context.WriteLine(result.ToString());
            Assert.IsNotNull(result);
        }

        /// <summary>
        /// 基本の投稿
        /// </summary>
        [TestMethod]
        public async Task Post()
        {
            var user = new Misq.Me(TestData.Host(), TestData.AccessToken());

            var api = new Misq.Wrapper.API(user);

            var result = await api.Note.Create(
                $"あー、あー。APIのテスト中。只今の時刻は{DateTime.UtcNow}です。",
                "followers");

            Context.WriteLine(result);
            Assert.IsNotNull(result);
        }
        /// <summary>
        /// 画像の投稿
        /// </summary>
        [TestMethod]
        public async Task Media()
        {
            var user = new Misq.Me(TestData.Host(), TestData.AccessToken());

            var api = new Misq.Wrapper.API(user);

            var result = await api.Drive.Files.Create(
                "test.png",
                @"data\chicken.png");

            Context.WriteLine(result);
            Assert.IsNotNull(result);
        }
    }
}