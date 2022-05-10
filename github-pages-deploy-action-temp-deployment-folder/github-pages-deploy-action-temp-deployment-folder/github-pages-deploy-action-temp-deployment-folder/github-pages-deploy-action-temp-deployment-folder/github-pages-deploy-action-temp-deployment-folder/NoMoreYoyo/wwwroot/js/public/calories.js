function CreatePostData() {
    let data = $('#calculator').serialize();

    return data;
}

function setupEvents() {
    let calculateBtn = document.querySelector('#calculateCalories');

    calculateBtn.addEventListener('click', function () {
        postData();
    });
}

function postData() {
    $.ajax({
        url: "CalculateCalories",
        type: "POST",
        data: CreatePostData(),
        success: function (response) {
            if (response.success) {
                alert("Calories: " + response.calories);
            }
            else {
                $('.card').html(response);
                setupEvents();
            }
        }
    });
}

setupEvents();