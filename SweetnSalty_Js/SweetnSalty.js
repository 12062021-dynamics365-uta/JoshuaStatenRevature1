let sweet = 0; 
let salt = 0;
let ss = 0;   //Setting variables to increment depending on if nth number is salty, sweet, or both
let n = 0;
let lbreak = ""; //default string that will be used for concatenation 


for(let n = 0; n <= 1000; n++) //Loop to continously generate numbers from 1-1000
{
    if(n % 3 == 0 && n % 5 == 0) //if nth number is evenly divisible by 3 AND 5, the salt n 'sweet counter will increment 
    {
        console.log("sweet'nSalty ");
        ss++;
    }
    else if(n % 3 == 0 ) //if nth number is evenly divisible by 3, the sweet counter will increment 
    {
        console.log("sweet ");
        sweet++;
    }
    else if(n % 5 == 0) //if nth number is evenly divisible by 5, the salty  counter will increment 
    {
        console.log("salty ");
        salt++
    }
    else //If none of the above, nth number will print normally and no counters will increment
    {
        console.log(n + " ");
    }
    if(n % 20 == 0) //Implements line break condition after every 20th number
    {
        console.log(lbreak);
        lbreak = ""; //must reset string to default position to start next up-to-20 loop
    }
}
    

console.log('Sweet: ', sweet, '\nSalty: ' , salt , '\nSweetnSalty: ' , ss);