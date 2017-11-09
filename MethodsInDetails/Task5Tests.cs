using NUnit.Framework;

namespace MethodsInDetails
{
    // класс обязательно нужно пометить таким аттрибутом (в NUnit)
    // чтобы подключить NUnit нужно установить Nuget-пакет и добавить `using NUnit.Framework`;
    // если у вас есть решарпер, то достаточно использовать комбинацию Ctrl-T+R (не отпуская Ctrl нажать по очереди T и R)
    // тесты можно дебажить, если нажать Ctrl-T+D
    // легко запомнить: Test Run (T+R) и Test Debug (T+D)
    // если решарпера нет, то во-первых, поставьте)) если не ставится или вы принципиально против, то есть MS Test Runner,
    // плиган для студии, в которой я уже не знаю команд, но она успешно интегрируется с NUnit сама собой
    [TestFixture]
    public class Task5Tests
    {
        private Task5 task5;

        // если метод пометить аттрибутом SetUp, то его тело будет выполняться перед каждым тестом
        // обычно сюда переносят создание экземпляра тестируемого класса или другие "инициализирующие" участки кода
        [SetUp]
        public void SetUp()
        {
            task5 = new Task5();
        }

        // само тело теста помечается аттрибутом Test
        [Test]
        public void TestTask5WhenNoLuckyNumbers()
        {
            /*
            1. Создайте входные данные (в моем случае, в переменной input)
            2. Передайте их в тестируемый метод и запишите полученное значение в переменную. Это будет "что реально вернулось"
            3. Сравните то, "что реально вернулось" с тем, "что должно было вернуться". Для этого используется Assert.

            Есть кучи разных ассертов, как правило, будет хватать: AreEqual(ожидаемое, действительное), True(действительное), False и так далее.
            */
            var input = new[] {1, 2};
            var actual = task5.LuckyFilter(input);

            Assert.AreEqual(0, actual.Length);
        }

        [Test]
        public void Test2()
        {
            var actual = task5.LuckyFilter(new[] {1, 2, 7, 17});

            // в NUnit можно "неглубоко" сравнивать массивы и анонимные объекты
            // это значит, что если у меня будет класс Person(int age) и я создам два его экземпляра с одним возрастом, они не будут равны
            // но вот если я сделаю "типа персону" в виде анонимного объекта, то они будут считаться одинаковыми
            // есть еще Assert.AreSame, но я без понятия, зачем он
            Assert.AreEqual(new [] {7, 17}, actual);
            Assert.AreNotEqual(new TestPerson(17), new TestPerson(17));
            Assert.AreEqual(new { age = 17 }, new { age = 17 });
        }

        private class TestPerson
        {
            public int Age;

            public TestPerson(int age)
            {
                Age = age;
            }
        }

        [Test]
        public void Test3()
        {
            var actual = task5.LuckyFilter(new[] {1, 7, 71, 77, 3});

            Assert.AreEqual(new [] {7, 71, 77}, actual);
        }
    }
}