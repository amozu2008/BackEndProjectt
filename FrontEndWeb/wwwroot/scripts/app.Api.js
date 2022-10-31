const ConsumeHttp = new HTTPClass;

const listData = document.querySelector("#listDataId");
const findCustomerBtn = document.querySelector("#findCustomerBtn");
const customerTxt = document.querySelector("#customerIdTxt");
const alertBox = document.querySelector("#alertBoxId");



allCustomerBtn.addEventListener("click", () => {
    ConsumeHttp.getCustomer("https://backenddotnotation.azurewebsites.net/api/account")
    /*ConsumeHttp.getCustomer("https://io.dotnotation.com.ng/api/account")*/ 
  /*  ConsumeHttp.getCustomer("https://localhost:44395/api/account")*/
        .then(data => {
            if (data.isSuccess) {
                let outputData = "";
                data.result.forEach(item => {
                    outputData += `<a href="#" class="list-group-item list-group-item-action">
                                    <div class="d-flex w-100 justify-content-between">
                                        <h5 class="mb-1">${item.customer.name} ${item.customer.surname}</h5>
                                        <small>initialCredit ${item.customer.initialCredit}</small>
                                    </div>
                                    <p class="mb-1">Balance ${item.balance}</p>
                                    <small>Transaction ${item.transactions}</small>
                            </a>`
                });
                listData.innerHTML = outputData;
            }
            else {
                alertBox.innerHTML = "Something went wrong";
                alertBox.classList.remove("alert-success");
                alertBox.classList.add("alert-danger");
                alertBox.classList.replace("d-none", "d-block");
            }



        })
        .catch(err => console.log(err));
});

findCustomerBtn.addEventListener("click", () => {
    let customerValue = customerTxt.value;

    if (customerValue == "") {

        alertBox.innerHTML = `Please enter all fields`;
        alertBox.classList.remove("alert-success");
        alertBox.classList.add("alert-danger");
        alertBox.classList.replace("d-none", "d-block");

    }
    else {
        alertBox.classList.replace("d-block", "d-none");
        listData.innerHTML = "";
        ConsumeHttp.getCustomer("https://backenddotnotation.azurewebsites.net/api/account/" + customerValue)
        /*ConsumeHttp.getCustomer("https://io.dotnotation.com.ng/api/account/" + customerValue)*/
        /*ConsumeHttp.getCustomer("https://localhost:44395/api/account/" + customerValue)*/
            .then(data => {
                if (data.isSuccess) {
                    let outputData = "";
                    data.result.forEach(item => {
                        outputData += `<a href="#" class="list-group-item list-group-item-action">
                                    <div class="d-flex w-100 justify-content-between">
                                        <h5 class="mb-1">${item.customer.name} ${item.customer.surname}</h5>
                                        <small>initialCredit ${item.customer.initialCredit}</small>
                                    </div>
                                    <p class="mb-1">Balance ${item.balance}</p>
                                    <small>Transaction ${item.transactions}</small>
                            </a>`
                    });
                    listData.innerHTML = outputData;
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