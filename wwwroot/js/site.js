// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

let finishedTodoButtons = document.querySelectorAll("#done");

// click event for the radioButtons
finishedTodoButtons.forEach((x) => {
    x.addEventListener("click", (e) => {
        if (e.target.checked) {
            // do something to get rid of the todo
        }
    })

});


// /// for todo form
// const form = document.querySelector("#createTodo");
// const msg = document.querySelector("#message");
// const todoTitle = document.querySelector("#title");
// const todoString = document.querySelector("#todo");


// form.addEventListener("submit", (e) => {
//     e.preventDefault();



//     console.log("form submitted to api")
//     fetch("/api/todos/create", {
//         method: "POST",
//         headers: {"Content-Type": "application/json"},
//         body: JSON.stringify({Title: todoTitle.value, TodoString: todoString.value})
//     })
//     .then(res => res.json())
//     .then(data => {
//         if (data?.errors) {
//             console.log("there was an eror");
//         }
//         else {
//             console.log("success!")
//         }
//     })
// })        



// convert all utc time to local time
const utcTimes = document.querySelectorAll(".utc-time");

utcTimes.forEach(time => {
    let date = new Date(time.textContent); 
    time.textContent = date.toLocaleString("en-us", {hour12: true, month: "2-digit", day: "2-digit", hour:"2-digit", minute: "2-digit"}); // this will conver the utc time to local time
});