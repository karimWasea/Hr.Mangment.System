


namespace ReprestoryServess
{
    public  class SalaryclackServesses
    {
        private  UserManager<Applicaionuser> _user;
        private  ApplicationDBcontext _Context;

        public  SalaryclackServesses(ApplicationDBcontext db, UserManager<Applicaionuser> user)
        {
            _user = user;
            _Context = db;
        }

        /// <summary>
        /// Calculate and update an employee's salary history based on transactions.
        /// </summary>
        /// <param name="employeeId">The unique identifier of the employee.</param>
        /// <param name="amount">The amount associated with the transaction.</param>
        /// <param name="transactionDateTime">The date and time of the transaction.</param>
        public   void CalculateSalary(string employeeId, decimal amount, DateTime transactionDateTime)
        {
            // Retrieve the employee's salary history for the current month, if it exists
            var currentMonthInHistoryTable = _Context.EmployeeHistories
                .Where(eh => eh.EmployeeId == employeeId)
                .Select(eh => eh.Month)
                .FirstOrDefault();

            // Retrieve the employee's current salary transaction for reference
            var historyTransaction = _Context.SalaryTransactions
                .Where(st => st.EmployeeId == employeeId)
                .FirstOrDefault();

            // Ensure that the transactionDateTime is set to the first day of the current month
            DateTime firstDayOfMonth = transactionDateTime.Date.AddDays(1 - transactionDateTime.Day);

            // Retrieve the employee's current total salary
            var totalSalary = _Context.Users
                .Where(u => u.Id == employeeId)
                .Select(u => u.Salary)
                .FirstOrDefault();

            if (currentMonthInHistoryTable != firstDayOfMonth)
            {
                // Create a new salary history entry for the current month
                var newHistoryEntry = new EmployeeHistory
                {
                    EmployeeId = employeeId,
                    Month = firstDayOfMonth
                };

                // Check the type of the previous salary transaction
                if (historyTransaction != null && historyTransaction.transactionTyp != TransactionSalaryType.Bonus)
                {
                    // Subtract the transaction amount from the total salary
                    newHistoryEntry.TotalSalary = (decimal?)totalSalary - amount;
                }
                else
                {
                    // Add the transaction amount to the total salary
                    newHistoryEntry.TotalSalary = (decimal?)totalSalary + amount;
                }

                // Add the new salary history entry to the context and save changes
                _Context.EmployeeHistories.Add(newHistoryEntry);
                _Context.SaveChanges();
            }
            else
            {
                // Update the existing salary history entry for the current month
                var updatedHistory = _Context.EmployeeHistories
                    .Where(eh => eh.EmployeeId == employeeId && eh.Month == firstDayOfMonth)
                    .FirstOrDefault();

                if (historyTransaction != null && historyTransaction.transactionTyp == TransactionSalaryType.Bonus && transactionDateTime >= firstDayOfMonth && transactionDateTime <= firstDayOfMonth.AddMonths(1).AddDays(-1))
                {
                    // Subtract the transaction amount from the total salary
                    updatedHistory.TotalSalary +=amount;
                }
                else if (historyTransaction != null && (historyTransaction.transactionTyp == TransactionSalaryType.debt || historyTransaction.transactionTyp == TransactionSalaryType.Deduction) && historyTransaction.TransactionDate >= firstDayOfMonth && historyTransaction.TransactionDate <= firstDayOfMonth.AddMonths(1).AddDays(-1))
                {
                    // Subtract the transaction amount from the total salary
                    updatedHistory.TotalSalary -=amount;
                }

                // Update the existing salary history entry in the context and save changes
                _Context.EmployeeHistories.Update(updatedHistory);
                _Context.SaveChanges();
            }
        }

    }
}
