using System.ComponentModel.DataAnnotations;

namespace AluguelRV.Shared.Enums;
public enum ExpenseType
{
    HouseBill = 1,
    Other = 2
}

public static class ExpenseTypeHelper
{
    public static string Display(ExpenseType? expenseType)
    {
        switch (expenseType)
        {
            case ExpenseType.HouseBill:
                return "Conta de Casa";
            case ExpenseType.Other:
                return "Outro";
            default:
                return "Desconhecido";
        }
    }
}