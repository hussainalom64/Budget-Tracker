using System;
using System.Collections.Generic;

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Microsoft.VisualBasic.FileIO;

namespace BudgetTracker
{

    class BudgetItem
    {
        // Private fields for the budget item
        private string description;
        private decimal amount;
        private bool isExpense;

        // Getters and setters for the budget item's properties
        public string Description
        {
            get { return description; }
            set { description = value; }
        }
        public decimal Amount
        {
            get { return amount; }
            set { amount = value; }
        }
        public bool IsExpense
        {
            get { return isExpense; }
            set { isExpense = value; }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //Make the budget list and the balance variables
            List<BudgetItem> budget = new List<BudgetItem>();
            decimal balance = 0;

            //Main loop for the program
            bool exit = false;
            while(!exit)
            {
                //Starting of the program
                Console.WriteLine("Welcome to myBudgetTracker");
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("1. Add a budget item");
                Console.WriteLine("2. View all budget items");
                Console.WriteLine("3. View current balance");
                Console.WriteLine("4. Edit a budget item");
                Console.WriteLine("5. Delete a budget item");
                Console.WriteLine("6. Exit");
                
                //Read the users choice
                int choice = int.Parse(Console.ReadLine());

                //Use a switch statement to do the appropriate action
                switch(choice)
                {
                    case 1:
                        Console.WriteLine("Enter the description for the Budget Item");
                        string description = Console.ReadLine();
                        Console.WriteLine("Enter the amount of the budget item");
                        decimal amount = decimal.Parse(Console.ReadLine());
                        Console.WriteLine("Is this an expense (y/n)");
                        string isExpenseInput = Console.ReadLine();
                        bool isExpense = isExpenseInput.ToLower() == "y";
                        BudgetItem item = new BudgetItem();
                        item.Description = description;
                        item.Amount = amount;
                        item.IsExpense = isExpense;
                        budget.Add(item);

                        if(isExpense)
                        {
                            balance -= amount;
                        }
                        else
                        {
                            balance += amount;
                        }
                        Console.WriteLine("Budget Item successfully added.");
                        break;
                    case 2:
                        //View all budget items
                        Console.WriteLine("Here are all the budget items");
                        for (int i = 0; i < budget.Count; i++)
                        {
                            BudgetItem currentItem = budget[i];
                            Console.WriteLine($"{i + 1}. {currentItem.Description} - ${currentItem.Amount} ({(currentItem.IsExpense ? "Expense" : "Income")})");
                        }
                        break;
                    case 3:
                        //View the balance
                        Console.WriteLine("Your current balance is $" + balance);
                        break;
                    case 4:
                        //Edit a budget item
                        Console.WriteLine("Enter the number of the budget item you would like to edit");
                        int index = int.Parse(Console.ReadLine()) - 1;

                        if(index >= 0 && index < budget.Count)
                        {
                            BudgetItem itemToEdit = budget[index];
                            Console.WriteLine("Enter the new description");
                            itemToEdit.Description = Console.ReadLine();
                            Console.WriteLine("Enter the new amount");
                            itemToEdit.Amount = decimal.Parse(Console.ReadLine());
                            Console.WriteLine("Is this an expense (y/n)?");
                            string newIsExpenseInput = Console.ReadLine();
                            itemToEdit.IsExpense = newIsExpenseInput.ToLower() == "y";
                            Console.WriteLine("Budget item editted successfully!");
                        }
                        else
                        {
                            Console.WriteLine("Invalid index, please try again!");
                        }
                        break;
                    case 5:
                        //Delete a budget item
                        Console.WriteLine("Enter the number of the budget you would like to delete");
                        int deleteIndex = int.Parse(Console.ReadLine()) - 1;

                        if(deleteIndex >= 0 && deleteIndex < budget.Count)
                        {
                            budget.RemoveAt(deleteIndex);
                            Console.WriteLine("Item successfully deleted");
                        }
                        else
                        {
                            Console.WriteLine("Invalid index.");
                        }
                        break;
                    case 6:
                        //Exit the budget tracker
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice, please try again!");
                        break;

                }
            }
        }
    }
    
}