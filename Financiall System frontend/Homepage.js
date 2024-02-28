function HomepageView(username) {
    const app = document.getElementById("app");
    app.innerHTML = /*HTML*/ `
    <div class="container">
    ${optionmenu(username)}
    ${Homepage(username)}
    </div>
      `;
  }


function Homepage(username){
return /*HTML*/`
<div class="Username ">Logged in as ${username}<div>
`;
} 


function optionmenu(username){
    user = username
    return /*html*/`
    <div class="hexagon"onmouseover="showOptions()" onmouseout="hideOptions()" >
    <div class="content" >
        <h1>Plan</h1>
    </div>
    
    
    <div class="options" >
            <div onclick="projectview()" class="hexagon element1">
                <div class="nr1">My projects</div>
            </div>
            <div onclick="DesignProject(user)" class="hexagon element2">
                <div class="nr2">Design project</div>
            </div>
            <div onclick="ForumView()" class="hexagon element3">
                <div class="nr3">Forum Project</div>
            </div>
        </div>
    `;
    }
    
    
