const ConsumeHttp = new HTTPClass;

const customerTxt = document.querySelector("#customerIdTxt");
const initialCreditTxt = document.querySelector("#initialCreditTxt");
const createBtn = document.querySelector("#btnid");
const alertBox = document.querySelector("#alertBoxId");




createBtn.addEventListener("click", () => {
    let customerValue = customerTxt.value;
    let creditValue = initialCreditTxt.value;

    if (customerValue == "" || creditValue == "") {

        alertBox.innerHTML = `Please enter all fields`;
        alertBox.classList.remove("alert-success");
        alertBox.classList.add("alert-danger");
        alertBox.classList.replace("d-none", "d-block");

    }
    else {
        alertBox.classList.replace("d-block", "d-none");
        const customerObj = {
            customerId : customerValue,
            initialCredit : creditValue
        }
        ConsumeHttp.registerUsers("https://backenddotnotation.azurewebsites.net/api/account", customerObj)
       /* ConsumeHttp.registerUsers("https://io.dotnotation.com.ng/api/account", customerObj) */
       /* ConsumeHttp.registerUsers("https://localhost:44395/api/account", customerObj)*/
            .then(data => {
                                if (data.isSuccess) {

                                    alertBox.innerHTML = data.displayMessages;
                                    alertBox.classList.remove("alert-danger");
                                    alertBox.classList.add("alert-success");
                                    alertBox.classList.replace("d-none", "d-block");
                                    customerTxt.value = "";
                                    initialCreditTxt.value = "";
                                }
                                else {
                                    alertBox.innerHTML = data.displayMessages;
                                    alertBox.classList.remove("alert-success");
                                    alertBox.classList.add("alert-danger");
                                    alertBox.classList.replace("d-none", "d-block");
                                }
                           })
            .catch(err => console.log(err));
    }

});

