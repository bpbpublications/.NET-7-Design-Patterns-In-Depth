
using UnitOdWork;

UnitOfWork unitOfWork = new UnitOfWork();
unitOfWork.BankAccountRepository.Add(new BankAccount { Id = 1001, AccountNumber = 123456 });
unitOfWork.UserRepository.Add(new User { Id = 1, Name = "Vahid" });

unitOfWork.Commit();

var bankaccount = unitOfWork.BankAccountRepository.Find(1001);
bankaccount.AccountNumber = 789;
unitOfWork.BankAccountRepository.Update(bankaccount);

unitOfWork.UserRepository.Delete(1);

unitOfWork.Commit();

Console.ReadLine();