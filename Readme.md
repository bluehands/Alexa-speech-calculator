# Assistants - the new app platform

This project give little instructions how to build an Alexa skill and is used in demos and talks. 

# Create the skill

* Goto https://developer.amazon.com/alexa/console/ask and create a new skill.
  * Add an indent *Add*
  * Add two slots *first* and *second* as AMAZON.Number
  * Add some sample utterances like *"Was macht {first} plus {second}"*, *"Was ergibt {first} und {second}"* and *"Was macht {first} und {second}"*
  * On every slot enable "Slot Filling" and add a prompt. E.q. "*Was ist die erste Zahl*"
* Add an invokation name e.q. "*online calculator*"
* Start ngroke "*ngrok.exe http 60804 -host-header="localhost" -region=eu*. Replace the port 60804 with your port number from the asp.net project  
  * In ASK, add an https endpoint to "*https://72dcacf3.eu.ngrok.io/api/alexa/calc*". Replace 72dcacf3 with the host given by ngroke.
  * Use wildcard certificates
* Save the model
* Build the model

# Create the backend
* Create a new asp.net project
  * Reference Alexa.NET from https://github.com/timheuer/alexa-skills-dotnet
  * Add a Controller e.q. "*AlexaController*" 
  * Add post route named e.q. "*calc*"
  * Parse the ask message and handle the intent 
 