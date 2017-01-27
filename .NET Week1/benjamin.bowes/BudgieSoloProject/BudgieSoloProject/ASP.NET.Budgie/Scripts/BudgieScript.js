/* Toggle between adding and removing the "responsive" class to topnav when the user clicks on the icon */


function myFunction() 
{
    var x = document.getElementById("myTopnav");
    if (x.className === "topnav") 
	{
        x.className += " responsive";
    }
		else 
	{
        x.className = "topnav";
    }
}

// USER AND Password 

var xmlHttp = new XMLHttpRequest(); // set operator
xmlHttp.open("GET", "data.xml", false); // give task to operator
xmlHttp.send(); // give task to operator
var xmlDoc = xmlHttp.responseXML; // set variable to the result of the operators task

var element =  xmlDoc.getElementsByTagName("account");

function pasuser()

{
	for(var i = 0; i < element.length; i++)
	{
		if (document.getElementById("id").value==element[i].getElementsByTagName("id")[0].childNodes[0].nodeValue)
		{ 
		if (document.getElementById("pass").value==element[i].getElementsByTagName("pass")[0].childNodes[0].nodeValue)
			{              
				location="Account.html"
			}
				else 
			{
				alert("Invalid Password")
			}
		}
	}
}


//var name= "Budgie"
//var mynumber= "10"
//var myElement = document.getElementById("div1");
//var myTextbox = document.getElementById("textbox");

//alert (myTextbox.value);

//alert (myElement.innerHTML);

/* Set Info on the HTML/DOM */
/*
var myText = document.getElementById("text");
myText.innerHTML = "New Text";

/* This is how to define a function */

/*
function exampleFunction()
{
console.log(name);
console.log(mynumber);
}

/*
function login(username)
{
	if(username == "Budgie")
	{
		alert("Welcome back " + username);
	}
	else if(username == "Alfred")
	{
		alert("Welcome back " + username);
	}
	else
	{
		alert("No entry");
	}

}

/* This is how to call a function */

/*
exampleFunction();
login("Budgie");
login("Parrot");
login("Pigeon");

/* Loops */

/*
function loops()
{
	for(var i = 0; i < 20; i++)
	{
		console.log(i);
	}
	
	while(mynumber < 20)
	{
		console.log(mynumber);
		mynumber = mynumber + 1;
	}
}

loops();

*/

//construct HTML elementFromPoint
//Insert the data from the XML into the HTML element
//Paste the HTML element on my page

var xmlHttp = new XMLHttpRequest(); // set operator
xmlHttp.open("GET", "data.xml", false); // give task to operator
xmlHttp.send(); // give task to operator
var xmlDoc = xmlHttp.responseXML; // set variable to the result of the operators task

//construct a HTML Element
var table = "<table><tr><th>Username</th><th>Password</th></tr>";

//Insert the data from the XML into the HTML element
var element =  xmlDoc.getElementsByTagName("account");

for(var i = 0; i <element.length; i++) //looping through the data to compare with what the person put in the input
{
	table += "<tr>";
	table += "<td>";
	table += element[i].getElementsByTagName("username")[0].childNodes[0].nodeValue;	//grabbing elements from the list
	table += "</td>";
	table += "<td>";
	table += element[i].getElementsByTagName("password")[0].childNodes[0].nodeValue;
	table += "</td>";
	table += "</tr>";
}

table += "</table>"; // closes the table

//Paste the HTML element on my page
document.getElementById("myData").innerHTML = table;







