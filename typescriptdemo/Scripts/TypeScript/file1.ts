alert("Hello world!");

var el: HTMLElement = document.getElementById('changeMe');

var type = (el instanceof HTMLElement) ? "HTMLElement" : "Unknown";

var message = "This element has been located and altered with TypeScript, and it has typeof: " + type.toString(); 
el.innerText = message;

