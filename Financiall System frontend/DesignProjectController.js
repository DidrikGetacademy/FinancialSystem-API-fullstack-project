function ProjectCreate(username){
    const Projectname = document.getElementById("Projectname").value;
    const description = document.getElementById("description").value;
    
    const data = {
        Title: Projectname,
        Description: description,
        Username: username,
    }
    
    fetch("https://localhost:5228/api/User/project", {
    method: "POST",
    headers: {
    "Content-Type": "application/json"
    },
    body: JSON.stringify(data)
    })
    .then((response) => {
    if(response.ok){
    alert("Sucsessfully added project to the database")
    }else if(response.status === 409){
      alert("Wrong Details")
    }else {
    alert("Something is not working right")
    }
    });
    }