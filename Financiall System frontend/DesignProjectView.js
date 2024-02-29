
function DesignProject(Username){
    const app = document.getElementById("app");
    app.innerHTML = /*HTML*/ `
    <div class="container">
    <img src="/images/back.png" class="GoBackimg" onclick="HomepageView(username)"><img>
    ${ProjectDetails(Username)}
    </div>
      `;



}
function ProjectDetails(Username){
return /*html*/ `
<div class="Project">
    <h1>Create New Project</h1>
    <div>
        <label class="NameLabel">Project Name</label>
        <input id="Projectname" class="InputName" required><br>
    </div>
    <div>
        <label class="DescriptionLabel">Description</label>
        <textarea id="description" class="DescriptionInput"></textarea>
    </div>
    <button class="CreateProjectsButton" onclick="ProjectCreate('${Username}')">Save</button>
</div>
`;

}

