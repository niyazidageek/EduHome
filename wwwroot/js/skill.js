
$(document).ready(function () {
    let count = 1;
    let addButton = document.getElementById("add-skill")
    var deleteButtons = document.querySelectorAll(".delete-skill")

    addButton.addEventListener("click", () => {
        count++
        let skillForm = document.getElementById("skill-form")
        $.ajax({
            type: "Get",
            url: `https://localhost:5001/admin/teacher/getskills?count=${count}`,
            success: function (result) {
                console.log(result)
                let formGroup = document.createElement("div")
                formGroup.className = "form-group"
                formGroup.style.display = "flex"
                $(formGroup).html(result);
                skillForm.append(formGroup)
                deleteButtons = document.querySelectorAll(".delete-skill")
                deleteButtons.forEach(btn => {
                    btn.addEventListener('click', () => {
                        let id = btn.getAttribute("data-id")
                        let form = document.querySelector(`.form-group[data-id="${id}"]`)
                        form.remove()
                        deleteButtons = document.querySelectorAll(".delete-skill")
                    })
                })
            }
        })
        
        console.log(deleteButtons)
    })

    deleteButtons.forEach(btn => {
        btn.addEventListener('click', () => {
            let id = btn.getAttribute("data-id")
            let form = document.querySelector(`.form-group[data-id="${id}"]`)
            form.remove()
            deleteButtons = document.querySelectorAll(".delete-skill")
        })
    })
});
