

using System.Threading;
using System.Threading.Tasks;

namespace ContactApp.Client
{
    public class Parallel
    {

        public void WorkWithThread()
        {
            var t1 = new Thread(() => {
                RunMethod(1000, 'A');
            });

            var t2 = new Thread(() => {
                RunMethod(10, 'B');
            });

            t1.Start(); // Right here there is t0 main thread but also t1 and t2
            t2.Start(); // The threads will run even after the main is finished
                        // The threads WILL run

            t1.Join();  // this joins t1 to main thread
            // t2.Join();

        }


        public void WorkWithTask()
        {
            var t1 = new Task(() => {
                RunMethod(1000, 'A');
            });

            var t2 = new Task(() => {
                RunMethod(10, 'B');
            });

            t1.Start(); // Right here there is t0 main thread but also t1 and t2
            t2.Start(); // The tasks will end when main thread is finished
                        // The tasks may not complete before main thread
            
            //Task.WaitAll(t1, t2); // This Makes both tasks complete

            Task.WaitAll(new Task[] {t1, t2}, 1000); // This proscribes wait time of main thread for task
                                                  // 2 is not enough time to wait
                                                  // 10 lets some of task complete
                                                  // 1000 lets all of task complete


        }

        public async Task WorkWithAsync()
        {
            await Task.Run(() => {
                RunMethod(1000, 'C');
            });
        }

        public void RunMethod(int num, char letter)
        {
            for(int i = 0; i < num; i++)
                System.Console.Write(letter);
        }
    }
}