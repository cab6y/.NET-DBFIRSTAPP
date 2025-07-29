const apiUrl = "/api/todoitems";
let modal;

$(document).ready(function () {
    const modalElement = document.getElementById('todoModal');
    if (modalElement) {
        modal = new bootstrap.Modal(modalElement);
    }

    loadTodos();

    $("#btnAdd").click(function () {
        clearModal();
        $("#todoModalLabel").text("Add Todo");
        if (modal) modal.show();
    });

    $("#saveTodo").click(function () {
        const id = $("#todoId").val();
        if (id) {
            updateTodo(id);
        } else {
            addTodo();
        }
    });
});

function loadTodos() {
    $.get(apiUrl + "/GetList", function (data) {
        const rows = data.map(todo => `
            <tr>
                <td>${todo.id}</td>
                <td>${todo.title}</td>
                <td>${todo.description}</td>
                <td>${todo.dueDate.split('T')[0]}</td>
                <td class="text-center">
                    ${todo.isCompleted
                ? '<span class="badge bg-success">&#10004;</span>'
                : '<span class="badge bg-danger">&#10006;</span>'}
                </td>
                <td>
                    <button class="btn btn-sm btn-warning" onclick="editTodo(${todo.id})">Edit</button>
                    <button class="btn btn-sm btn-danger" onclick="confirmDelete(${todo.id})">Delete</button>
                </td>
            </tr>
        `).join("");
        $("#todoTable tbody").html(rows);
    });
}

function addTodo() {
    const todo = {
        title: $("#title").val(),
        description: $("#description").val(),
        dueDate: $("#dueDate").val(),
        isDeleted: false,
        isCompleted: $("#isCompleted").is(":checked")
    };

    $.ajax({
        url: apiUrl + "/Add",
        type: "POST",
        contentType: "application/json",
        data: JSON.stringify(todo),
        success: function () {
            if (modal) modal.hide();
            Swal.fire("Success!", "Todo has been added successfully.", "success");
            loadTodos();
        },
        error: function () {
            Swal.fire("Error!", "An error occurred while adding the todo.", "error");
        }
    });
}

function editTodo(id) {
    $.get(apiUrl + "/Get?id=" + id, function (todo) {
        $("#todoId").val(todo.id);
        $("#title").val(todo.title);
        $("#description").val(todo.description);
        $("#dueDate").val(todo.dueDate.split('T')[0]);
        $("#isCompleted").prop("checked", todo.isCompleted);

        $("#todoModalLabel").text("Update Todo");
        if (modal) modal.show();
    });
}

function updateTodo(id) {
    const todo = {
        id: id,
        title: $("#title").val(),
        description: $("#description").val(),
        dueDate: $("#dueDate").val(),
        isCompleted: $("#isCompleted").is(":checked"),
        creationTime: new Date().toISOString()
    };

    $.ajax({
        url: apiUrl + "/Update?id=" + id,
        type: "PUT",
        contentType: "application/json",
        data: JSON.stringify(todo),
        success: function () {
            if (modal) modal.hide();
            Swal.fire("Success!", "Todo has been updated successfully.", "success");
            loadTodos();
        },
        error: function () {
            Swal.fire("Error!", "An error occurred while updating the todo.", "error");
        }
    });
}

function confirmDelete(id) {
    Swal.fire({
        title: "Are you sure?",
        text: "Do you really want to delete this todo?",
        icon: "warning",
        showCancelButton: true,
        confirmButtonText: "Yes, delete it!",
        cancelButtonText: "No, cancel"
    }).then((result) => {
        if (result.isConfirmed) {
            deleteTodo(id);
        }
    });
}

function deleteTodo(id) {
    $.ajax({
        url: apiUrl + "/Delete?id=" + id,
        type: "DELETE",
        success: function () {
            Swal.fire("Deleted!", "Todo has been deleted successfully.", "success");
            loadTodos();
        },
        error: function () {
            Swal.fire("Error!", "An error occurred while deleting the todo.", "error");
        }
    });
}

function clearModal() {
    $("#todoId").val("");
    $("#title").val("");
    $("#description").val("");
    $("#dueDate").val("");
    $("#isCompleted").prop("checked", false);
}
