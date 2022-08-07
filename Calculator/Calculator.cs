namespace Calculator;

public class Calculator
{
    
    private string opperator ;
    private string[] numbers;
    private decimal result;
    private string decorationsSmall = "****";
    private string decorationsLarge = "***************************************";
    private string[] errors = new string[2] { " Invalid input ", " !!!! Division by 0" };
    
    public void ShowMessage( string message ) 
    {
        Console.WriteLine( message );
    }
    
     
     public void GetOperator()
     {
        while ( opperator == null)
        {
            Console.WriteLine( "****  Choose operator (+,-,*,/)" );
            Console.Write( $"{decorationsSmall}       " );
            var input = Console.ReadLine();
          
            opperator = CheckOperatorIsValid( input ) ? input : null;   
        }
    }

     
     public void Reset()
     {
         opperator = null;
     }


     public void GetNumbers()
     {
         var finished = false;
         while ( finished == false )
         {
             Console.WriteLine( $"{ decorationsSmall }  enter numbers seperated with space" );
             Console.Write( $"{decorationsSmall} " );
             var input = Console.ReadLine();
             var InputNumbers = input.Split(" ");

             foreach (var number in InputNumbers)
             {
                 if (!CheckNumberInputIsValid( number ))
                 {
                     Console.WriteLine( "****  Did you use space ?" );
                     break;
                 }
                 numbers = InputNumbers;
                 finished = true;
             }
         }
    }
     
     
     private static bool CheckOperatorIsValid( string input )
     {
         return input is "+" or "-" or "*" or "/";
     } 

     
    private static bool CheckNumberInputIsValid( string input )
    {
        if (input.Length >= 1 )
        {
            return decimal.TryParse(input, out var value2);
        }

        return false;

    }

    
    private string PrepareResultMessage()
    {
        string numberString = numbers[0];
        var i = 1;
        while ( i < numbers.Length )
        {
            numberString += " " + opperator + " " + numbers[i] + " " ;
            i++;
            if (i > numbers.Length)
            {
                i = numbers.Length;
            }
        }
       

        return numberString;
    }

    
    public void DoOpperation()
    { 
        switch ( opperator )
        {
            case "+":
                result = Addition( numbers );
                break;
            case "-":
                result = Subtraction( numbers);
                break;
            case "*":
                result = Multiplication( numbers );
                break;
            case "/":
                result = Division( numbers );
                break;
        }
    } 

    
    public void ShowResult()
    {
        Console.WriteLine( $"{ decorationsSmall }   { PrepareResultMessage() } = { result } " );
    }

    
    private decimal Addition( string[] numbers )
    {
        decimal sum = 0 ;
        foreach (var number in numbers)
        {
           sum += Convert.ToDecimal( number );
        }
        return sum;
    }
    
    
    private decimal Subtraction( string[] numbers )
    {
        decimal difference =  Convert.ToDecimal(numbers[0]) ;
        for (int x = 1; x < numbers.Length; x++)
        {
            difference = difference - Convert.ToDecimal(numbers[x]);
        }
        return difference;
    }
    
    private decimal Multiplication( string[] numbers )
    {
        decimal product = 1 ;
        foreach (var number in numbers)
        {
            product =  product * Convert.ToDecimal(number);
        }
        return product;
    }
    
    
    private decimal Division( string[] numbers )
    {
        decimal fraction =  Convert.ToDecimal(numbers[0]) ;
        for (int y = 1; y < numbers.Length; y++)
        {
            var number = Convert.ToDecimal(numbers[y]); 
            if (number == 0 )
            {
                ShowMessage( errors[1]);
                break;
            }
            fraction = fraction / number;
        }
        return fraction;
    }
}