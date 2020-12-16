using System;
using System.Diagnostics;
using System.Threading;

namespace ThreadTest
{
    class Program
    {
        #region Example 1  创建线程   交替打印主线程与子线程的数据
        //static void Main(string[] args)
        //{
        //    //设置主线程名
        //    Thread.CurrentThread.Name = "主线程";

        //    //开启子线程，并设置名
        //    Thread thread = new Thread(PrintNumbers);
        //    thread.Name = "子线程";
        //    thread.Start();
        //    //主线程中调用PrintNumbers()方法
        //    PrintNumbers();
        //    Console.ReadKey();
        //}
        ///// <summary>
        ///// 输出数字
        ///// </summary>
        //static void PrintNumbers()
        //{
        //    var threadName = Thread.CurrentThread.Name;
        //    Console.WriteLine("当前线程：" + threadName);
        //    for (int i = 0; i < 10; i++)
        //    {
        //        Console.WriteLine(threadName + "：" + i);
        //    }
        //}
        #endregion

        #region Example 2  暂停线程
        //static void Main(string[] args)
        //{
        //    //设置主线程名
        //    Thread.CurrentThread.Name = "主线程";

        //    //开启子线程，并设置名
        //    Thread thread = new Thread(PrintNumbersWithDelay);
        //    thread.Name = "子线程";
        //    thread.Start();
        //    //主线程中调用PrintNumbers()方法
        //    PrintNumbers();
        //    Console.ReadKey();
        //}
        ///// <summary>
        ///// 输出数字
        ///// </summary>
        //static void PrintNumbers()
        //{
        //    var threadName = Thread.CurrentThread.Name;
        //    Console.WriteLine("当前线程：" + threadName);
        //    for (int i = 0; i < 10; i++)
        //    {
        //        Console.WriteLine(threadName + "：" + i);
        //    }
        //}

        ///// <summary>
        ///// 延迟输出数字
        ///// </summary>
        //static void PrintNumbersWithDelay()
        //{
        //    var threadName = Thread.CurrentThread.Name;
        //    Console.WriteLine("当前线程：" + threadName);
        //    for (int i = 0; i < 10; i++)
        //    {
        //        Thread.Sleep(TimeSpan.FromSeconds(1));//每次都暂停1秒再执行输出操作
        //        Console.WriteLine(threadName + "：" + i);
        //    }
        //}
        #endregion

        #region Example 3  线程等待
        //static void Main(string[] args)
        //{
        //    //设置主线程名
        //    Thread.CurrentThread.Name = "主线程";

        //    //开启子线程，并设置名
        //    Thread thread = new Thread(PrintNumbersWithDelay);
        //    thread.Name = "子线程";
        //    thread.Start();
        //    thread.Join();//线程等待，等待子线程执行完后，才会继续往下执行
        //    Console.WriteLine(Thread.CurrentThread.Name+"执行结束。。。");
        //    Console.ReadKey();
        //}
        ///// <summary>
        ///// 延迟输出数字
        ///// </summary>
        //static void PrintNumbersWithDelay()
        //{
        //    var threadName = Thread.CurrentThread.Name;
        //    Console.WriteLine("当前线程：" + threadName);
        //    for (int i = 0; i < 10; i++)
        //    {
        //        Thread.Sleep(TimeSpan.FromSeconds(1));//每次都暂停四秒再执行输出操作
        //        Console.WriteLine(threadName + "：" + i);
        //    }
        //}
        #endregion

        #region Example 4  线程终止
        //static void Main(string[] args)
        //{
        //    Console.WriteLine("Starting program...");
        //    Thread t = new Thread(PrintNumbersWithDelay);
        //    t.Start();
        //    Thread.Sleep(TimeSpan.FromSeconds(6));
        //    t.Abort();
        //    Console.WriteLine("A thread has been aborted");
        //}

        //static void PrintNumbersWithDelay()
        //{
        //    Console.WriteLine("Starting...");
        //    for (int i = 1; i < 10; i++)
        //    {
        //        Thread.Sleep(TimeSpan.FromSeconds(2));
        //        Console.WriteLine(i);
        //    }
        //}
        #endregion

        #region Example 5  检测线程状态
        //static void Main(string[] args)
        //{
        //    //设置主线程名
        //    Thread.CurrentThread.Name = "主线程";
        //    Console.WriteLine(Thread.CurrentThread.Name + "：" + Thread.CurrentThread.ThreadState.ToString());
        //    Thread t = new Thread(PrintNumbersWithStatus);
        //    t.Name = "子线程";
        //    t.Start();
        //    for (int i = 0; i < 10; i++)
        //    {
        //        Console.WriteLine("主线程中打印子线程状态，当前子线程：{0}，其状态为：{1}", t.Name, t.ThreadState.ToString());
        //    }
        //    Thread.Sleep(TimeSpan.FromSeconds(5));
        //    t.Join();
        //    Console.WriteLine(t.Name + "：" + t.ThreadState.ToString());
        //    //t.Abort();
        //    //Console.WriteLine(t.Name + "：" + t.ThreadState.ToString());
        //    Console.WriteLine("执行结束。。。");
        //    Console.ReadKey();
        //}
        ///// <summary>
        ///// 
        ///// </summary>
        //static void PrintNumbersWithStatus()
        //{
        //    for (int i = 0; i < 5; i++)
        //    {
        //        Thread.Sleep(TimeSpan.FromSeconds(1));
        //        Console.WriteLine(Thread.CurrentThread.Name + ":" + i);
        //    }

        //}
        #endregion

        #region Example 6  线程优先级
        //static void Main(string[] args)
        //{
        //    Console.WriteLine("当前线程优先级（priority）: {0}", Thread.CurrentThread.Priority);
        //    Console.WriteLine("不限定计算机处理器核数进行计算与输出！");
        //    RunThreads();//不限定处理器核数，并开启线程
        //    Thread.Sleep(TimeSpan.FromSeconds(2));
        //    Console.WriteLine("设置当前为单核处理器并进行计算与输出！");
        //    Process.GetCurrentProcess().ProcessorAffinity = new IntPtr(1);
        //    RunThreads();//限定为单核处理器并进行计算与输出！
        //}
        /// <summary>
        /// 开启两个线程，并调用计数器
        /// </summary>
        static void RunThreads()
        {
            var sample = new ThreadSample();

            var threadOne = new Thread(sample.CountNumbers);
            threadOne.Name = "线程一";
            var threadTwo = new Thread(sample.CountNumbers);
            threadTwo.Name = "线程二";

            //设置线程一优先级级别为最高
            threadOne.Priority = ThreadPriority.Highest;
            //设置线程二优先级级别为最低
            threadTwo.Priority = ThreadPriority.Lowest;
            threadOne.Start();
            threadTwo.Start();
            //线程暂停两秒
            Thread.Sleep(TimeSpan.FromSeconds(2));
            //停止子线程的计算操作
            sample.Stop();
        }
        #endregion

        #region Example 7 前台线程与后台线程
        //static void Main(string[] args)
        //{
        //    var sampleForeground = new ThreadFrontBackSample(5);
        //    var sampleBackground = new ThreadFrontBackSample(10);

        //    var threadOne = new Thread(sampleForeground.CountNumbers);
        //    threadOne.Name = "前台线程";
        //    var threadTwo = new Thread(sampleBackground.CountNumbers);
        //    threadTwo.Name = "后台线程";
        //    threadTwo.IsBackground = true;

        //    threadOne.Start();
        //    threadTwo.Start();
        //}
        #endregion

        #region Example 8 向线程传递参数
        //static void Main(string[] args)
        //{

        //    //匿名委托方式传递参数
        //    var t = new Thread(() => PrintNumber(20));
        //    t.Name = "匿名委托线程一";
        //    var t2 = new Thread(() => PrintStr("匿名委托线程二传递过来的参数"));
        //    t2.Name = "匿名委托线程二";
        //    t.Start();
        //    t2.Start();

        //    //调用ParameterizedThreadStart委托
        //    Thread t3 = new Thread(new ParameterizedThreadStart(PrintStr));
        //    t3.Name = "调用ParameterizedThreadStart委托线程三";
        //    t3.Start("调用ParameterizedThreadStart传递过来的参数");

        //}
        ///// <summary>
        ///// 输出传递过来的数值
        ///// </summary>
        ///// <param name="number"></param>
        //static void PrintNumber(int number)
        //{
        //    Console.WriteLine("{0}的值为：【{1}】", Thread.CurrentThread.Name, number);
        //}

        ///// <summary>
        ///// 输出传递过来的字符串
        ///// </summary>
        ///// <param name="str"></param>
        //static void PrintStr(string str)
        //{
        //    Console.WriteLine("{0}的值为：{1}", Thread.CurrentThread.Name, str);
        //}

        ///// <summary>
        ///// 使用ParameterizedThreadStart输出传递过来的字符串
        ///// </summary>
        ///// <param name="str"></param>
        //static void PrintStr(object str)
        //{
        //    Console.WriteLine("{0}的值为：{1}", Thread.CurrentThread.Name, str);
        //}

        #endregion

        #region Example 9 lock参数使用
        //static void Main(string[] args)
        //{
        //    Console.WriteLine("错误计算：");

        //    var c = new Counter();

        //    var t1 = new Thread(() => TestCounter(c));
        //    var t2 = new Thread(() => TestCounter(c));
        //    t1.Start();
        //    t2.Start();
        //    t1.Join();
        //    t2.Join();

        //    Console.WriteLine("结果为: {0}", c.Count);
        //    Console.WriteLine("--------------------------");

        //    Console.WriteLine("正确计算：");

        //    var c1 = new CounterWithLock();

        //    t1 = new Thread(() => TestCounter(c1));
        //    t2 = new Thread(() => TestCounter(c1));
        //    t1.Start();
        //    t2.Start();
        //    t1.Join();
        //    t2.Join();
        //    Console.WriteLine("结果为: {0}", c1.Count);

        //}

        //static void TestCounter(CounterBase c)
        //{
        //    for (int i = 0; i < 100000; i++)
        //    {
        //        c.Increment();
        //        c.Decrement();
        //    }
        //}
        #endregion

        #region Example 10 死锁
        //static void Main(string[] args)
        //{
        //    object lock1 = new object();
        //    object lock2 = new object();

        //    new Thread(() => LockTooMuch(lock1, lock2)).Start();

        //    Console.WriteLine("----------------------------------");
        //    lock (lock2)
        //    {
        //        Console.WriteLine("主线程锁定lock2输出!");
        //        Thread.Sleep(1000);
        //        lock (lock1)
        //        {
        //            Console.WriteLine("主线程锁定lock1输出！");
        //        }
        //    }
        //}
        ///// <summary>
        ///// 给lock1和lock2加锁
        ///// </summary>
        ///// <param name="lock1"></param>
        ///// <param name="lock2"></param>
        //static void LockTooMuch(object lock1, object lock2)
        //{
        //    lock (lock1)
        //    {
        //        Console.WriteLine("子线程锁定lock1输出!");
        //        Thread.Sleep(1000);
        //        lock (lock2) { Console.WriteLine("子线程锁定lock2输出！"); }
        //    }
        //}
        #endregion

        #region Example 11 Monitor类避免死锁
        //static void Main(string[] args)
        //{
        //    object lock1 = new object();
        //    object lock2 = new object();

        //    new Thread(() => LockTooMuch(lock1, lock2)).Start();
        //    for (int i = 0; i < 2; i++)
        //    {
        //        lock (lock2)
        //        {
        //            Thread.Sleep(1000);
        //            Console.WriteLine("Monitor.TryEnter在经过指定时间内无法拿到所需资源，则返回false，这可避免死锁！");
        //            if (Monitor.TryEnter(lock1, TimeSpan.FromSeconds(5)))//如果当前线程获得锁，则为true；否则为false。
        //            {
        //                Console.WriteLine("主线程：成功请求被保护资源！");
        //            }
        //            else
        //            {
        //                Console.WriteLine("主线程：资源请求超时！");
        //            }
        //        }
        //    }
        //}

        ///// <summary>
        ///// 给lock1和lock2加锁
        ///// </summary>
        ///// <param name="lock1"></param>
        ///// <param name="lock2"></param>
        //static void LockTooMuch(object lock1, object lock2)
        //{
        //    lock (lock1)
        //    {
        //        Console.WriteLine("子线程锁定lock1输出!");
        //        Thread.Sleep(1000);
        //        lock (lock2) { Console.WriteLine("子线程锁定lock2输出！"); }
        //    }
        //}
        #endregion

        #region Example 12 异常处理
        static void Main(string[] args)
        {
            //创建一个子线程，并在子线程中捕获异常，可正常通过
            var t = new Thread(FaultyThread);
            t.Start();
            t.Join();

            try
            {
                //在主线程中捕获子线程的异常，无法捕获，会直接在子线程中抛出
                t = new Thread(BadFaultyThread);
                t.Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine("捕获到了子线程异常：{0}",ex.Message);
            }
        }
        /// <summary>
        /// 子线程中抛出，想要主线程捕获（但事实上主线程是无法捕获的）
        /// </summary>
        static void BadFaultyThread()
        {
            Console.WriteLine("下面将会抛出一个异常，但是不想自己处理，想给主线程处理！");
            Thread.Sleep(TimeSpan.FromSeconds(2));
            throw new Exception("Boom!");//debug模式下会走这一句
        }
        /// <summary>
        /// 子线程中捕获异常
        /// </summary>
        static void FaultyThread()
        {
            try
            {
                Console.WriteLine("下面将会抛出一个异常，将自己主动处理！");
                Thread.Sleep(TimeSpan.FromSeconds(1));
                throw new Exception("Boom!");//debug模式下会走catch
            }
            catch (Exception ex)
            {
                Console.WriteLine("FaultyThread()方法中捕获到了线程的异常: {0}", ex.Message);
            }
        }
        #endregion

    }
    #region Example 6 线程优先级
    /// <summary>
    /// 线程优先级
    /// </summary>
    class ThreadSample
    {
        //定义一个暂停标识
        private bool _isStopped = false;

        //设置暂停的方法
        public void Stop()
        {
            _isStopped = true;
        }
        /// <summary>
        /// 数值统计并输出当前线程名与线程优先级
        /// </summary>
        public void CountNumbers()
        {
            //计数器
            long counter = 0;


            while (!_isStopped)
            {
                counter++;
            }
            //输出当前线程名+线程优先级+计数器最终结果
            Console.WriteLine("{0} with {1,11} priority " +
                        "has a count = {2,13}", Thread.CurrentThread.Name,
                        Thread.CurrentThread.Priority,
                        counter.ToString());
        }



    }
    #endregion
    #region Example 7 前后台线程
    /// <summary>
    /// 前后台线程
    /// </summary>
    class ThreadFrontBackSample
    {
        //计算范围
        private readonly int _iterations;

        /// <summary>
        /// 创建类的时候通过构造函数给_iterations赋值
        /// </summary>
        /// <param name="iterations"></param>
        public ThreadFrontBackSample(int iterations)
        {
            _iterations = iterations;
        }
        /// <summary>
        /// 计算一定范围内数值之和
        /// </summary>
        public void CountNumbers()
        {
            for (int i = 0; i < _iterations; i++)
            {
                Thread.Sleep(TimeSpan.FromSeconds(0.5));
                Console.WriteLine("{0} prints {1}", Thread.CurrentThread.Name, i);
            }
        }
    }

    #endregion

    #region Example 9 lock参数使用
    class Counter : CounterBase
    {
        public int Count { get; private set; }

        /// <summary>
        /// 计数器++
        /// </summary>
        public override void Increment()
        {
            Count++;
        }
        /// <summary>
        /// 计数器--
        /// </summary>
        public override void Decrement()
        {
            Count--;
        }
    }

    class CounterWithLock : CounterBase
    {

        private readonly object _syncRoot = new Object();

        public int Count { get; private set; }

        public override void Increment()
        {
            //使用locak锁住，当count++执行完后，才可再次使用count
            lock (_syncRoot)
            {
                Count++;
            }
        }

        public override void Decrement()
        {
            //使用locak锁住，当count--执行完后，才可再次使用count
            lock (_syncRoot)
            {
                Count--;
            }
        }
    }
    /// <summary>
    /// 抽象的计算类   抽出公共部分
    /// </summary>
    abstract class CounterBase
    {
        public abstract void Increment();

        public abstract void Decrement();
    }
    #endregion
}
