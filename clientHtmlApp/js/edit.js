async function editOrder()
{
    let s = window.location.search;
    let id = s.match(new RegExp("id" + '=([^&=]+)'))[1];
    let providerId = await document.sform.inputProvider.selectedIndex;

    let orderItem = await getOrderItemByOrderId(Number(id));

    isEqual(document.sform.inputNumber.value, document.sform.inputName.value, "Номер заказа и имя заказа не должно совпадать!")

    let response = await fetch(`https://localhost:7252/api/Order/${id}`,
    {
        method: "PUT",
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

    alert("Успешно!");
    await fetch(`https://localhost:7252/api/OrderItem/${orderItem.id}`,
    {
        method: "PUT",
        headers: {
            "Accept": "application/json",
            "Content-Type": "application/json"
        },
        body: JSON.stringify(
            {
                orderId: id,
                name: document.sform.inputName.value,
                quantity: document.sform.inputQuantity.value,
                unit: document.sform.inputModel.value
            }
        )
    });
    window.location.replace(`index.html`);
}