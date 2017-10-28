using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SELab01Example;
using NUnit.Framework;

namespace SELab01ExampleTest
{
    [TestFixture]
    public class test
    {
        [Test()]
        public void Cola_Test()
        {
            Goods cola = new GoodsREGULAR("Cola");
            Item i1 = new Item(cola, 6, 65);
            Customer x = new Customer("test", 10);
            Bill b1 = new Bill(x);
            b1.addGoods(i1);
            string actual = b1.statement();
            string expected = "Счет для test\n\tНазвание\tЦена\tКол-воСтоимость\tСкидка\tСумма\tБонус\n\tCola\t\t65\t6\t390\t11,7\t368,3\t19\nСумма счета составляет 368,3\nВы заработали 19 бонусных балов";
            Assert.AreEqual(expected, actual);
        }

        [Test()]
        public void Pepsi_Test()
        {
            Goods pepsi = new GoodsREGULAR("Pepsi");
            Item i1 = new Item(pepsi, 3, 50);
            Customer x = new Customer("test", 10);
            Bill b1 = new Bill(x);
            b1.addGoods(i1);
            string actual = b1.statement();
            string expected = "Счет для test\n\tНазвание\tЦена\tКол-воСтоимость\tСкидка\tСумма\tБонус\n\tPepsi\t\t50\t3\t150\t4,5\t145,5\t7\nСумма счета составляет 145,5\nВы заработали 7 бонусных балов";
            Assert.AreEqual(expected, actual);
        }

        [Test()]
        public void Fanta_Test()
        {
            Goods fanta = new GoodsREGULAR("Fanta");
            Item i1 = new Item(fanta, 1, 35);
            Customer x = new Customer("test", 10);
            Bill b1 = new Bill(x);
            b1.addGoods(i1);
            string actual = b1.statement();
            string expected = "Счет для test\n\tНазвание\tЦена\tКол-воСтоимость\tСкидка\tСумма\tБонус\n\tFanta\t\t35\t1\t35\t0\t35\t1\nСумма счета составляет 35\nВы заработали 1 бонусных балов";
            Assert.AreEqual(expected, actual);
        }

        [Test()]
        public void Cola_and_Pepsi_Test()
        {
            Goods cola = new GoodsREGULAR("Cola");
            Goods pepsi = new GoodsSALE("Pepsi");
            Item i1 = new Item(cola, 6, 65);
            Item i2 = new Item(pepsi, 3, 50);
            Customer x = new Customer("test", 10);
            Bill b1 = new Bill(x);
            b1.addGoods(i1);
            b1.addGoods(i2);
            string actual = b1.statement();
            string expected = "Счет для test\n\tНазвание\tЦена\tКол-воСтоимость\tСкидка\tСумма\tБонус\n\tCola\t\t65\t6\t390\t11,7\t368,3\t19\n\tPepsi\t\t50\t3\t150\t0\t150\t1\nСумма счета составляет 518,3\nВы заработали 20 бонусных балов";
            Assert.AreEqual(expected, actual);
        }

        [Test()]
        public void Cola_and_Fanta_Test()
        {
            Goods cola = new GoodsREGULAR("Cola");
            Goods fanta = new GoodsSALE("Fanta");
            Item i1 = new Item(cola, 6, 65);
            Item i2 = new Item(fanta, 1, 35);
            Customer x = new Customer("test", 10);
            Bill b1 = new Bill(x);
            b1.addGoods(i1);
            b1.addGoods(i2);
            string actual = b1.statement();
            string expected = "Счет для test\n\tНазвание\tЦена\tКол-воСтоимость\tСкидка\tСумма\tБонус\n\tCola\t\t65\t6\t390\t11,7\t368,3\t19\n\tFanta\t\t35\t1\t35\t0\t35\t0\nСумма счета составляет 403,3\nВы заработали 19 бонусных балов";
            Assert.AreEqual(expected, actual);
        }

        [Test()]
        public void Pepsi_and_Fanta_Test()
        {
            Goods pepsi = new GoodsREGULAR("Pepsi");
            Goods fanta = new GoodsSALE("Fanta");
            Item i1 = new Item(pepsi, 3, 50);
            Item i2 = new Item(fanta, 1, 35);
            Customer x = new Customer("test", 10);
            Bill b1 = new Bill(x);
            b1.addGoods(i1);
            b1.addGoods(i2);
            string actual = b1.statement();
            string expected = "Счет для test\n\tНазвание\tЦена\tКол-воСтоимость\tСкидка\tСумма\tБонус\n\tPepsi\t\t50\t3\t150\t4,5\t145,5\t7\n\tFanta\t\t35\t1\t35\t0\t35\t0\nСумма счета составляет 180,5\nВы заработали 7 бонусных балов";
            Assert.AreEqual(expected, actual);
        }

        [Test()]
        public void Cola_and_Pepsi_and_Fanta_Test()
        {
            Goods cola = new GoodsREGULAR ("Cola");
            Goods pepsi = new GoodsREGULAR("Pepsi");
            Goods fanta = new GoodsSALE("Fanta");
            Item i1 = new Item(cola, 6, 65);
            Item i2 = new Item(pepsi, 3, 50);
            Item i3 = new Item(fanta, 1, 35);
            Customer x = new Customer("test", 10);
            Bill b1 = new Bill(x);
            b1.addGoods(i1);
            b1.addGoods(i2);
            b1.addGoods(i3);
            string actual = b1.statement();
            string expected = "Счет для test\n\tНазвание\tЦена\tКол-воСтоимость\tСкидка\tСумма\tБонус\n\tCola\t\t65\t6\t390\t11,7\t368,3\t19\n\tPepsi\t\t50\t3\t150\t4,5\t145,5\t7\n\tFanta\t\t35\t1\t35\t0\t35\t0\nСумма счета составляет 548,8\nВы заработали 26 бонусных балов";
            Assert.AreEqual(expected, actual);
        }
    }
}
