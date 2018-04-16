using Mazzsoft.CodeDBL.Core;
using Mazzsoft.CodeDBL.Core.Shared.Attributes;
using Mazzsoft.CodeDBL.Core.Shared.Bases;
using Mazzsoft.CodeDBL.Core.Shared.Enums;
using System;
using System.Linq;

namespace CodeDBLCLI
{
    class Program
    {
        public static void Main(String[] args)
        {
            string credentials = "Server=localhost; Database=Tests; User Id=sa; Password=123;";
            var DB = new CodeDBL(DatabaseManagementSystem.SQLServer, credentials) { Timeout = 1000 };

            if (DB.IsConnected)
            {
                //Simple
                Console.WriteLine($"Data do banco: {DB.Select("getdate()")}");

                var uuid = DB.Select("newid()").ToString();
                Console.WriteLine($"Data do banco: {uuid}");

                //Disposable
                using (var rand = DB.Select("RAND() AS Random;"))
                {
                    var r = rand.SingleOrDefault();
                    Console.WriteLine($"{r.Key}: {r.Value}");
                }
                        

                using (var products = DB.Select("nome", "preco").From<Products>(prod => prod.Id.Equals("063A8229-BA79-4113-A699-5BC8AA0ED9AC")))
                    Console.WriteLine($"Produtos: {products}");                
            }

            Console.Read();
        }
    }

    [Table("Produtos", "uuid")]
    public class Products : Entity
    {
        [Column("uuid")]
        public string Id { get; set; }

        [Column("nome", Coalesce = "Nome não informado.")]
        public string Name { get; set; }
    }
}
