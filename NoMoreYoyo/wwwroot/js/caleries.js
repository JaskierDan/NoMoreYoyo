const calCal = document.getElementsByClassName("calCal");
const calculButton = document.getElementById("calculationButton")
const dailyCal = document.getElementsByClassName("dailyCal");
const sendButton = document.getElementById("caloriesButton");

calculButton.addEventListener("click", calculation);
sendButton.addEventListener("click", caloriesSend);

function caloriesSend() {
    const calorie = document.getElementById("calorie");
    const protein = document.getElementById("protein");
    const carbohydrate = document.getElementById("carbohydrate");
    const fat = document.getElementById("fat");
    const errorDivCalorie = document.getElementById("errorDivCalorie");
    const errorMessage = document.getElementById("errorMessageCalorie");

    try {
        if (calorie.value.length == 0 || protein.value.length == 0 || carbohydrate.value.length == 0 || fat.value.length ==0) {
            throw "You have not filled in all input!";
        } else {
            if (calorie.value < 1 || protein.value < 1 || carbohydrate.value < 1 || fat.value < 1) {
                throw "Fileds cannot be less than 1!";
            } else {
                errorDivCalorie.style.display = "none";
                console.log("sikerekes adatbevitel");
                //there will be saved the datas
            }
        }
    } catch (err) {
        errorDivCalorie.style.display = "block";
        errorMessage.innerHTML = err;
    }

}

function calculation() {
    const male = document.getElementById("male");
    const weight = document.getElementById("weight");
    const height = document.getElementById("height");
    const age = document.getElementById("age");
    const activity = document.getElementById("activity");
    const message = document.getElementById("errorMessage");
    const errorDiv = document.getElementById("errorDiv");
    const calculatedCal = document.getElementById("calculatedCal");
    const calculatedCalMessage = document.getElementById("calculatedCalMessage");

    try {
        if (weight.value.length == 0 || height.value.length == 0 || age.value.length == 0) {
            throw "You have not filled in all input!"
        } else {
            if (weight.value < 1 || height.value < 1 || age.value < 1) {
                throw "Fileds cannot be less than 1!"
            } else {
                errorDiv.style.display = "none";
                let sum;
                if (male.checked) {
                    sum = (66 + 13.7 * weight.value + 5 * height.value - 6.8 * age.value) * parseFloat(activity.value);
                } else {
                    sum = (665 + 9.6 * weight.value + 1.7 * height.value - 4.7 * age.value) * parseFloat(activity.value);
                }
                calculatedCal.style.display = "block";
                calculatedCalMessage.innerHTML = "Your calculated calories: " + Math.round(sum);
            }
        }
        
    }
    catch (err) {
        errorDiv.style.display = "block";
        message.innerHTML = err;
    }

    


}
