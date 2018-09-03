using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace HW_XML_1_03._09._2018
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu();
        }

        public static void Menu()
        {
            bool inProgress = true;

            while (inProgress)
            {
                Console.WriteLine(new string('-', 80));
                Console.WriteLine("" +
                    "1. Задание 1. \n" +
                    "2. Задание 2. \n" +
                    "3. Выход\n");
                Console.WriteLine(new string('-', 80));
                Console.Write("> ");

                int ch = 0;
                Int32.TryParse(Console.ReadLine(), out ch);

                switch (ch)
                {
                    case 1:
                        {
                            Task1();
                        }
                        break;
                    case 2:
                        {
                            Task2();
                        }
                        break;
                    case 3:
                        {
                            inProgress = false;
                        }
                        break;
                    default:
                        Console.WriteLine("Повторите ввод");
                        break;
                }

            }

        }


        static void Task1()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("Currency.xml");

            // получаем корневой элемент
            XmlElement xRoot = doc.DocumentElement;

            List<Bank> banks = new List<Bank>();

            // обход всех узлов в корневом элементе
            foreach (XmlNode item in xRoot)
            {
                Bank bank = new Bank();
                // получаем атрибут банка
                if (item.Attributes.Count > 0)
                {
                    XmlNode attr = item.Attributes.GetNamedItem("name");
                    if (attr != null)
                    {
                        bank.Name = attr.Value;
                    }
                }
                // обходим все дочерние узлы элемента bank
                foreach (XmlNode child in item.ChildNodes)
                {
                    if (child.Name == "buy")
                    {
                        bank.Buy = child.InnerText;
                    }
                    if (child.Name == "sale")
                    {
                        bank.Sale = child.InnerText;
                    }
                }
                banks.Add(bank);
            }
            Console.WriteLine(new string('-', 50));
            Console.WriteLine("\t\tКУРС ВАЛЮТ");
            Console.WriteLine(new string('-', 50));

            foreach (Bank item in banks)
            {
                Console.WriteLine(item.ToString());
            }
            Console.WriteLine(new string('-', 50));
            Console.WriteLine("Информация сохранена в файле CurrencySave.xml");
            Console.WriteLine(new string('-', 50));
            doc.Save("CurrencySave.xml");

        }

        static void Task2()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("Goods.xml");

            // получаем корневой элемент
            XmlElement xRoot = doc.DocumentElement;

            Console.WriteLine(new string('-', 50));
            Console.WriteLine("Исходный файл: ");
            Console.WriteLine(new string('-', 50));

            foreach (XmlNode item in xRoot)
            {
                // получаем атрибут заказа
                if (item.Attributes.Count > 0)
                {
                    XmlNode attr = item.Attributes.GetNamedItem("id");
                    if (attr != null)
                    {
                        Console.WriteLine("Заказ #{0}:", attr.Value);
                    }
                }
                // обходим все дочерние узлы элемента goods
                foreach (XmlNode child in item.ChildNodes)
                {
                    if (child.Name == "commodity")
                    {
                        Console.WriteLine("Товар {0}:", child.InnerText);
                    }
                }

                Console.WriteLine();
            }

            // Создаем новый элемент order
            XmlElement orderElem = doc.CreateElement("order");

            // создаем атрибут id
            XmlAttribute idOrderAttr = doc.CreateAttribute("id");

            // создаем элементы commodity и id
            XmlElement commElem1 = doc.CreateElement("commodity");
            XmlAttribute idCommAttr1 = doc.CreateAttribute("id");
            XmlElement commElem2 = doc.CreateElement("commodity");
            XmlAttribute idCommAttr2 = doc.CreateAttribute("id");
            XmlElement commElem3 = doc.CreateElement("commodity");
            XmlAttribute idCommAttr3 = doc.CreateAttribute("id");
            XmlElement commElem4 = doc.CreateElement("commodity");
            XmlAttribute idCommAttr4 = doc.CreateAttribute("id");
            XmlElement commElem5 = doc.CreateElement("commodity");
            XmlAttribute idCommAttr5 = doc.CreateAttribute("id");

            // создаем текстовые значения для элементов и атрибутов
            XmlText idOrderAttrText = doc.CreateTextNode("5");

            XmlText commElem1Text = doc.CreateTextNode("Товар 1");
            XmlText idCommAttr1Text = doc.CreateTextNode("1");
            XmlText commElem2Text = doc.CreateTextNode("Товар 2");
            XmlText idCommAttr2Text = doc.CreateTextNode("2");
            XmlText commElem3Text = doc.CreateTextNode("Товар 3");
            XmlText idCommAttr3Text = doc.CreateTextNode("3");
            XmlText commElem4Text = doc.CreateTextNode("Товар 4");
            XmlText idCommAttr4Text = doc.CreateTextNode("4");
            XmlText commElem5Text = doc.CreateTextNode("Товар 5");
            XmlText idCommAttr5Text = doc.CreateTextNode("5");

            // добавляем узлы
            idOrderAttr.AppendChild(idOrderAttrText);

            commElem1.AppendChild(commElem1Text);
            idCommAttr1.AppendChild(idCommAttr1Text);
            commElem2.AppendChild(commElem2Text);
            idCommAttr2.AppendChild(idCommAttr2Text);
            commElem3.AppendChild(commElem3Text);
            idCommAttr3.AppendChild(idCommAttr3Text);
            commElem4.AppendChild(commElem4Text);
            idCommAttr4.AppendChild(idCommAttr4Text);
            commElem5.AppendChild(commElem5Text);
            idCommAttr5.AppendChild(idCommAttr5Text);

            orderElem.Attributes.Append(idOrderAttr);

            orderElem.AppendChild(commElem1);
            orderElem.Attributes.Append(idCommAttr1);
            orderElem.AppendChild(commElem2);
            orderElem.Attributes.Append(idCommAttr2);
            orderElem.AppendChild(commElem3);
            orderElem.Attributes.Append(idCommAttr3);
            orderElem.AppendChild(commElem4);
            orderElem.Attributes.Append(idCommAttr4);
            orderElem.AppendChild(commElem5);
            orderElem.Attributes.Append(idCommAttr5);

            xRoot.AppendChild(orderElem);

            doc.Save("Goods.xml");

            Console.WriteLine(new string('-', 50));
            Console.WriteLine("Файл после изменения: ");
            Console.WriteLine(new string('-', 50));

            foreach (XmlNode item in xRoot)
            {
                // получаем атрибут заказа
                if (item.Attributes.Count > 0)
                {
                    XmlNode attr = item.Attributes.GetNamedItem("id");
                    if (attr != null)
                    {
                        Console.WriteLine("Заказ #{0}:", attr.Value);
                    }
                }
                // обходим все дочерние узлы элемента goods
                foreach (XmlNode child in item.ChildNodes)
                {
                    if (child.Name == "commodity")
                    {
                        Console.WriteLine("Товар {0}:", child.InnerText);
                    }
                }

                Console.WriteLine();
            }
        }
    }
}
