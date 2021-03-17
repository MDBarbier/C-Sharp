using System;
using System.Xml.Linq;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            
            var xmlString = "<root xmlns:ns2=\"http://nsTwo\">" +
                "<ns1:childone xmlns:ns1=\"http://one\">c1</ns1:childone>" +
                "<ns1:childone xmlns:ns1=\"http://nsthree\">c1</ns1:childone>" +
                "<ns2:childtwo>c2</ns2:childtwo>" +
                "<ns2:childtwo xmlns:ns2=\"http://alttwo\">" +
                "<ns2:child>xxx</ns2:child>" +
                "</ns2:childtwo>" +
                "<ns2:childtwo>c2</ns2:childtwo>" +
                "</root>";

            var xmlString2 = "<root>" +
                "<ns0:toplevel1 xmlns:ns0=\"http://nszero\">" +
                "<ns0:secondLevelOne>aaa</ns0:secondLevelOne>" +
                "<ns0:secondLevelTwo>" +
                "<ns0:thirdlevel1 xmlns:ns0=\"http://nszeroinner\">" +
                "<ns0:fourthLevel>hello world</ns0:fourthLevel>" +
                "</ns0:thirdlevel1>" +
                "</ns0:secondLevelTwo>" +
                "<ns0:secondLevelThree>bbb</ns0:secondLevelThree>" +
                "</ns0:toplevel1>" +
                "</root>";

            var doc2 = XDocument.Parse(xmlString2);

            foreach (var item in doc2.Descendants())
            {
                Console.WriteLine(item.Name);
            }

            Console.WriteLine("\n\n");
            Console.WriteLine(doc2.ToString());

        }
    }
}
