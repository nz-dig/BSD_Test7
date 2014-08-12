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
           // MyEntityContext context = new MyEntityContext();

            //using (IUnitOfWork uow = new UnitOfWork(new MyEntityContext()))
            //{
            //    MyEntityContext context = (MyEntityContext)uow.Context;
            //}

           // MainUOW();
            var context = new MyEntityContext();
            var e3 = context.Persons.FirstOrDefault(x => "Juliet_Binoche" == x.Id);
            
            using (IUnitOfWork uow = new UnitOfWork(context))
            {
                var extId = "Juliet_Binoche";
                var all = uow.GetRepository<IPerson>().GetAll();
                var entity = all.Where(x => x.Id == "Juliet_Binoche").FirstOrDefault();


                
                var e1 = uow.GetRepository<IPerson>().GetAll().FirstOrDefault(x => x.Id == "38e0c45f-14df-47e0-9a13-fac9f7b73cbd");
                var e2 = uow.GetRepository<IPerson>().GetById("38e0c45f-14df-47e0-9a13-fac9f7b73cbd");
                var p = uow.GetRepository<IPerson>().Create();
                p.FirstName = "Matt";
                p.LastName = "Jones";

               uow.SaveChanges();

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

               // uow.GetRepository<IEntity>().Add(person1);

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
