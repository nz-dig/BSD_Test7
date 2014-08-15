using BSD_Test7.Models;
using BSD_Test7.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSD_Test7
{
    class Program
    {
        static void Main(string[] args)
        {
           //// MainUOW();

           // var context = new MyEntityContext();

            
           // using (IUnitOfWork uow = new UnitOfWork(context))
           // {
           //     var id = "32775041-ac70-43f3-a7f5-8a5101cdb99b";

           //     var e1 = uow.GetRepository<IPerson>().GetAll().FirstOrDefault(x => x.Id == id);
           //     var e2 = uow.GetRepository<IPerson>().GetAll().FirstOrDefault(x => x.Id.Equals(id)); ;
           //     var e3 = uow.GetRepository<IPerson>().GetById(id);

           // }

            TestRepositoryPattern();
        }

       
        public static void TestRepositoryPattern()
        {
            var storeName = "TestRepositoryPattern" + DateTime.Now.Ticks;
            string id;
           
            using ( var context = new MyEntityContext())
            {
                var uow = new TempUnitOfWork(context);
                var repo = new TempRepository<IPerson>(uow);
                var derived = repo.Create();
                derived.FirstName = "Danny";
                derived.FirstName = "Mayers";
           
                context.SaveChanges();
                id = derived.Id;
            }

            using ( var context = new MyEntityContext())
            {
                var uow = new TempUnitOfWork(context);
                var repo = new TempRepository<IPerson>(uow);
                var derived = repo.GetById(id);
              
            }

        }
        static void MainUOW()
        {
            using (IUnitOfWork uow = new UnitOfWork(new MyEntityContext()))
            {
                var person1 = new Person();
                person1.FirstName = "Juliet";
                person1.LastName = "Binoche";
                person1.Id = "Juliet_Binoche";


                uow.GetRepository<IPerson>().Add(person1);

                var production1 = new Production();
                production1.Title = "Mademoiselle_Julie_2012";
                production1.Id = "Mademoiselle_Julie_2012";

                uow.GetRepository<IProduction>().Add(production1);

                var character1 = new Character();
                character1.Name = "Mademoiselle_Julie";
                character1.Id = "Mademoiselle_Julie";
                uow.GetRepository<ICharacter>().Add(character1);

                var credit1 = new Credit();
                credit1.Label = "Actor";
                credit1.Id = "actor";
                uow.GetRepository<ICredit>().Add(credit1);

                var role1 = new Role();
                role1.Production = production1;
                role1.Character = character1;
                role1.Credit = credit1;
                uow.GetRepository<IRole>().Add(role1);

                production1.Performers.Add(person1);
                person1.Roles.Add(role1);

                var ctx = (MyEntityContext)uow.Context;
                var p = ctx.Persons;

                uow.SaveChanges();

            }




        }
       
        static void MainDirect()
        {
            MyEntityContext context = new MyEntityContext();

            var person1 = new Person();
            person1.FirstName = "Juliet";
            person1.LastName = "Binoche";
            person1.Id = "Juliet_Binoche";

            context.Persons.Add(person1);

            var production1 = new Production();
            production1.Title = "Mademoiselle_Julie_2012";
            production1.Id = "Mademoiselle_Julie_2012";

            context.Productions.Add(production1);

            var character1 = new Character();
            character1.Name = "Mademoiselle_Julie";
            character1.Id = "Mademoiselle_Julie";
            context.Characters.Add(character1);

            var credit1 = new Credit();
            credit1.Label = "Actor";
            credit1.Id = "actor";
            context.Credits.Add(credit1);

            var role1 = new Role();
            role1.Production = production1;
            role1.Character = character1;
            role1.Credit = credit1;
            context.Roles.Add(role1);

            production1.Performers.Add(person1);
            person1.Roles.Add(role1);


            context.SaveChanges();


        }
    }
}
