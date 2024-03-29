﻿/*
    c# factorial implementation for positive 
    whole numbers.
    
    @datetime:: February 28, 2024 2:56 am (UTC-5)
    @author:: jac0der
*/
// importing arbitrary-precision arithmetic datatypes namespace.
using System.Numerics;

const long LONGUPPERBOUND = 9223372036854775807;

/***
    Function to get input number from user. Prompt user for an input
    until a valid input is provided.
    @input::    none
    @output::   number successfully cast from string input to integer.
***/
int get_input()
{
    int number;
    do
    {
        try
        {
            Console.Write("Enter number: ");

            // accept number from user  and explicitly cast to integer.          
            number = Convert.ToInt32(Console.ReadLine());

            // check for negatives and ignore
            if(number <= 0)
            {
                Console.WriteLine("Please provide a positive integer.");
            }
            else
            {
                // return valid positive number
                return number;
            }
        }
        catch(FormatException fe)
        {
            Console.WriteLine("Please provide a numeric input.");
            Console.WriteLine(fe.Message);
        }       
    }
    while(true);
}

/***
    Function to find the factorial of a number
    @input::int -> number
        number to retrieve factorial for.

    @output::BigInteger   
        factorial of input number using BigInteger
        Arbitrary-precision arithmetic datattype,
        to handle factorial results of large numbers.
***/
BigInteger factorial(int number)
{     
    // 1! is 1 so return 1 - base case met
    if(number == 1)
        return 1;

    // recursively call factorial on number - 1
    BigInteger fact = number * factorial(number - 1);

    return fact;
}

/***
    main function used to start the progam process of
    finding the factorial.
    @input:: none
    @output:: none (void function)
***/
void calculate_factorial()
{
    BigInteger result;
    int user_input = get_input();

    if(user_input >= 0)
    {
        result = factorial(user_input);

        if(result > LONGUPPERBOUND)
        {
            // print factorial result in scientific notation with e+15 format
            Console.WriteLine($"Factorial of {user_input} is: " + result.ToString("e15"));
        }
        else
        {
            // print factorial result in raw format since result is less than the max a
            // long datatype can hold.
            Console.WriteLine($"Factorial of {user_input} is: " + result.ToString());
        }
    }
}

// call method to start the process
calculate_factorial();