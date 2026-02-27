Exercise 1: 

Student Attendance & Eligibility System
A college tracks attendance for each subject. Attendance is captured daily as integers.
At the end of the semester, attendance percentage is calculated as a double.
University rules state that eligibility must be displayed as an integer percentage.
Design logic to:
• Store raw attendance data
• Calculate percentage
• Convert the value safely for display
• Explain rounding vs truncation impact


Answer:

using System;

class AttendanceSystem
{
    static void Main()
    {
        int totalClasses = 120;
        int attendedClasses = 86;


        double percentage = (double)attendedClasses / totalClasses * 100;

        
        int truncatedPercentage = (int)percentage;

        
        int roundedPercentage = (int)Math.Round(percentage);

        Console.WriteLine("Attendance Percentage (Double): " + percentage);
        Console.WriteLine("Displayed (Truncated): " + truncatedPercentage + "%");
        Console.WriteLine("Displayed (Rounded): " + roundedPercentage + "%");

    }
}

Explanation:

Truncation → When rules are strict and conservative
Rounding → When fairness to students is preferred


Exercise 2:

Online Examination Result Processing
An online exam system stores marks per subject as int.
The final average must be shown with two decimal places.
Later, scholarship eligibility requires converting the average into an int.
Design the conversion flow and explain precision loss scenarios.


Answer:

int sub1 = 78, sub2 = 85, sub3 = 92;

double average = (sub1 + sub2 + sub3) / 3.0;

Console.WriteLine("Average: " + average.ToString("F2"));

int avgRounded = (int)Math.Round(average);

Explanation:

int conversion removes decimals
Truncation may wrongly disqualify students
Rounding is safer for eligibility decisions



Exercise 3: 

Library Fine Calculation System
Fine per day is configured as decimal.
Days overdue are stored as int.
Total fine must be displayed as decimal but logged as double for analytics.
Explain why different types are used and how conversions occur.


Answer:

decimal finePerDay = 2.50m;
int daysLate = 6;

decimal totalFine = finePerDay * daysLate;

double fineForAnalytics = (double)totalFine;

Explanation:

Decimal- financial accuracy
double- fast analytics, acceptable minor error
Explicit cast prevents accidental precision loss


Exercise 4: 

Banking Interest Calculation Module
Account balance is decimal.
Interest rate is float from an external API.
Monthly interest is calculated and added to balance.
Demonstrate safe conversions and explain why implicit conversion may fail.


Answer:

decimal balance = 50000m;
float rate = 6.5f;

decimal interest = balance * (decimal)rate / 100;
balance += interest;

Explanation:

Float->Decimal is not implicit
precision mismatch
Compiler forces explicit cast to avoid hidden errors

Exercise 5: 

E-Commerce Order Pricing Engine
Cart total is accumulated using double.
Tax and discount rules require decimal.
Final payable amount is stored as decimal.
Explain conversion strategy and precision risks


Answer:

double cartTotal = 1499.99;

decimal tax = 0.18m;
decimal discount = 100m;

decimal finalAmount = (decimal)cartTotal;
finalAmount += finalAmount * tax;
finalAmount -= discount;

Explanation:

Precision Risks->
double may store 1499.98999..
Always convert to decimal before money operations



Exercise 6: 

Weather Monitoring & Reporting
Temperature sensors send readings as short.
Values must be converted to Celsius and stored as double.
Daily average is converted to int for dashboard display.
Discuss overflow and casting concerns.

Answer:

short rawTemp = 302; 

double celsius = (rawTemp / 10.0) - 273.15;
int displayTemp = (int)Math.Round(celsius);

Explanation:

Concerns->
short overflow if sensor misbehaves
Always cast before arithmetic
Rounding preferred for display


Exercise 7: 

University Grading Engine
Final score is calculated as double.
Grades are stored as byte values.
Design logic to convert score to grade safely.
Explain validation and casting choices.


Answer:

double score = 86.4;
byte grade;

if (score >= 90) grade = 10;
else if (score >= 80) grade = 9;
else if (score >= 70) grade = 8;
else grade = 5;

Explanation:

Why No direct cast?
Grades are bounded
Validation avoids invalid byte values
Business logic > raw casting


Exercise 8: 

Mobile Data Usage Tracker
Usage is tracked in bytes as long.
Displayed in MB and GB as double.
Monthly summary rounds values to nearest integer.
Explain implicit conversions and rounding methods.


Answer:

long bytesUsed = 5368709120;

double usageGB = bytesUsed / (1024.0 * 1024 * 1024);
int monthlySummary = (int)Math.Round(usageGB);

Explanation:

Implicit conversion : long-> double
Rounding avoids misleading totals
Safe range for double

Exercise 9: 

Warehouse Inventory Capacity Control
Item count stored as int.
Maximum capacity stored as ushort.
Conversion required during comparison and reporting.
Explain signed vs unsigned conversion risks.


Answer:

int itemsStored = 5000;
ushort maxCapacity = 6000;

if (itemsStored <= maxCapacity)
{
    Console.WriteLine("Within capacity");
}

Explanation:

ushort cannot hold negatives
Signed vs Unsigned mismatch
Convert to Int for safe comparison 


Exercise 10: 

Payroll Salary Computation
Basic salary is int.
Allowances and deductions are double.
Net salary stored as decimal.
Design type conversion flow and justify choices.



Answer:

int basicSalary = 40000;
double allowance = 5500.75;
double deduction = 2500.25;

decimal netSalary = basicSalary;
netSalary += (decimal)allowance;
netSalary -= (decimal)deduction;

Explanation:

int -> fixed salary
double -> variable inputs
decimal-> financial accuracy
