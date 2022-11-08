async function createOrder(){

    isEqual(document.sform.inputNumber.value, document.sform.inputName.value, "Номер заказа и имя заказа не должно совпадать!")


    let providerId = await document.sform.inputProvider.selectedIndex;

    let response = await fetch("https://localhost:7252/api/Order/",
    {
        method: "POST",
        headers: {
            "Accept": "application/json",
            "Content-Type": "application/json"
        },
        body: JSON.stringify(
            {
                number: document.sform.inputNumber.value,
                date: document.sform.inputDate.value,
                providerId: document.sform.inputProvider.options[providerId].value
            }
        )
    });

    if (response.status === 500)
    {
        alert("Не должно существовать 2х заказов от одного поставщика с одинаковыми номерами!");
	throw new Error("Не должно существовать 2х заказов от одного поставщика с одинаковыми номерами!");
    }

    let ordersList = await getOrders();
    let order = ordersList[ordersList.length-1];
    alert("Успешно!");
    
    await fetch("https://localhost:7252/api/OrderItem/",
    {
        method: "POST",
        headers: {
            "Accept": "application/json",
            "Content-Type": "application/json"
        },
        body: JSON.stringify(
            {
                orderId: order.id,
                name: document.sform.inputName.value,
                quantity: document.sform.inputQuantity.value,
                unit: document.sform.inputModel.value
            }
        )
    });

    window.location.replace(`index.html`);
}
