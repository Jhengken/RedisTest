using System.Diagnostics;using StackExchange.Redis;

Console.WriteLine("Hello, World!");

var redis = ConnectionMultiplexer.Connect("172.20.128.1:6379");
var db = redis.GetDatabase();

var stopwatch = new Stopwatch();
Console.WriteLine(stopwatch.ElapsedMilliseconds);
stopwatch.Start();
var redisKey = "840";

for (int i = 0; i < 20_000; i++)
{
    await db.HashExistsAsync(redisKey, "field"+i);
    // await db.HashGetAsync(redisKey, "field"+i);
    // await db.HashSetAsync(redisKey, $"field{i}",i.ToString());
}
stopwatch.Stop();
Console.WriteLine(stopwatch.ElapsedMilliseconds);


