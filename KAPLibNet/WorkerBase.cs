
namespace KAPLibNet
{
     public abstract class WorkerBase: IDisposable
    {
        const int SLEEP_TIME = 500;
        readonly protected CancellationToken Token;
        readonly protected ILogger Log;


        public WorkerBase(ILogger log,CancellationToken token)
        {
            Log = log;
            Token = token;
        }

        public abstract void Dispose();
        public abstract void Work();

        protected void Sleep(int msec)
        {
            //一度にスリープすると、キャンセルへの反応が遅れるため。
            int sleep_count = msec / SLEEP_TIME;
            for (int i = 0; i < sleep_count; i++) {
                Thread.Sleep(SLEEP_TIME);
                Token.ThrowIfCancellationRequested();
            }
        }

        protected void Error(Exception ex)
        {
            Log.Ex(ex);
        }

        protected void ThrowIfCancellationRequested()
        {
            Token.ThrowIfCancellationRequested();
        }
    }
}
