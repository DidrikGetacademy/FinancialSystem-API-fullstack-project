function registerUser(){
    const passwordinput = document.getElementById('username').value;
    const usernameinput = document.getElementById('password').value;
  
    
    // Oppretter et objekt med brukerdata
    const userData = {
      Username: usernameinput,
      Password: passwordinput,
    };
  
    // Utfører en HTTP-forespørsel for å registrere brukeren
  fetch("http://localhost:5280/api/User/register", {
  method: "POST", //POST-metoden brukes til å sende data fra en klient  til en server for å opprette en ny ressurs på serveren.
  headers: {
  "Content-Type": "application/json",// Setter innholdstypen til JSON
  },
  body: JSON.stringify(userData),// Sender brukerdata som JSON
  }).then((response) => {// Behandler svaret fra serveren
  if(response.ok){// Hvis responsen er OK (status 200-299)
  
  alert("register sucsessfull")// Viser en suksessmelding
  } else if (response.status === 409){// Hvis brukeren allerede eksisterer (konflikt)
   alert("User already Exsist with this username or email") // Viser en melding om at brukeren allerede eksisterer
  }else {
  alert("register Failed")// Viser en melding om at registreringen mislyktes
  }
  });
  }