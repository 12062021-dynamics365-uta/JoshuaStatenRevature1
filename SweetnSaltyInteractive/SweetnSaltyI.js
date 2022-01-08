let sweet = 0;
let salt = 0;
let ss = 0;
let FinalSweet = document.createElement('h3');
let FinalSalty = document.createElement('h3');
let Finalss = document.createElement('h3');

let prompt = document.createElement("h1");
let num = document.createElement("input");
let num2 = document.createElement("input");
let forward = document.createElement('button');
let testforward = document.createElement('button'); 
let search1;
let search2;
let space;
let reset = document.createElement('button');

let intro = document.createElement('h2');
document.body.appendChild(intro);
intro.innerText = ("Welcome to the Sweet n' Salty Game! \nYou will enter 2 numbers as long as their range is between 200 and 10,000. \nThen, all numbers in-between will be displayed, and we categorize each number as sweet, salty both, or both depending on if they are divisible by 3, 5, or both.");

let begin =  document.createElement('button');
document.body.appendChild(begin);
begin.innerText = 'Ready to start? Click to begin!';

begin.addEventListener('click', (e) => {
    document.body.innerHTML = '';
    document.body.appendChild(prompt);
    prompt.innerText = 'Please enter the first number';
    document.body.appendChild(num);
    document.body.appendChild(forward);
    forward.innerText = 'Press to continue';

});

forward.addEventListener('click', (e) => {
    document.body.innerHTML = '';
    search1 = num.value;
    num.value = '';
    document.body.appendChild(prompt);
    prompt.innerText = 'Please enter the second number';
    document.body.appendChild(num2);
    document.body.appendChild(testforward);
    testforward.innerText = 'Press to continue';

});

testforward.addEventListener('click', (e) => {
    search2 = num2.value;
    num.value = '';
    ExamRange(search1, search2);
    ExamNeg(search1,search2);
    Flavors(search1, search2);
    /*if(ExamRange(search1, search2) && ExamNeg(search1, search2))
    {
        Flavors(search1, search2);
    }*/
    
});

function ExamRange(search1, search2)
{
    if (search2 - search1 < 200)
    {
        prompt.innerText = "The distance between your two numbers must be more than 200";
        location.reload();
       
    }
    else if (search2 - search1 < 10,000)
    {
        prompt.innerHTML = "The distance between your two numbers must be less than 10,000 ";
        location.reload();
        
    }
    else if (search2 < search1)
    {
        prompt.innerHTML = "Oops! Your second number must be greater than the first. Sorry!! ";
        location.reload();
        
    }
    return;
}

function ExamNeg(search1, search2)

{
    if(search1 < 0 || search2 < 0)
    {
        prompt.innerHTML = "Uh-oh! You need positive numbers, not anything else for this!";
        location.reload(); 
        
    }
    else
    {
        return;
    }
    
}

function Flavors(search1, search2)
{
    let n = search1;
    let printer = '';
    for(n; n <= search2; n++)
    {
        if(n % 3 == 0 && n % 5 == 0 )
        {
            printer += '<span>SweetnSalty</span>';
            ss++;
        }
        else if (n % 3 == 0)
        {
            printer += '<span>Sweet</span';
            sweet++;
        }
        else if(n % 5 == 0)
        {
            printer += '<span>Salty</span>';
            salt++;
        }
        else
        {
            printer += n += ' ';
            if (n => 1000)
            {
                printer += ' ${n.toLocaleString()}';
            }
        }
        if (n % 40 == 0)
        {
            space = document.createElement('p');
        }
    }
 
    document.body.appendChild(FinalSweet);
    FinalSweet.innerText = '<span>Sweet</span>: ${sweet}';
    document.body.appendChild(FinalSalty);
    FinalSalty.innerText = '<span>Salty</span>: ${salt}';
    document.body.appendChild(Finalss);
    FinalSalty.innerText = '<span>SweetnSalty</span>: ${ss}';

    document.body.appendChild(prompt);
    prompt.innerText = 'Please click the button to start again';
    document.body.appendChild(reset);
    reset.innertext = 'Play Again? Click Here!';


}
reset.addEventListener('click', (e) => {
    location.reload();
});

