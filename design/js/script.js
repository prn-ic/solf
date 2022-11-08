function isEqual(value1, value2, exText)
{
    if (value1 === value2)
    {
	alert(exText);
	throw new Error(exText);
    }
}

async function showOrderInfo(id)
{
    let div = document.getElementById('modal-body-show');
    div.innerHTML = "";
    let newDiv = document.createElement('div');
    let order = await getOrderById(id);
    let orderItem = await getOrderItemByOrderId(order.id);

    let text = `<p><b>Id</b>: ${order.id}</p>`;
    text += `<p><b>Имя</b>: ${orderItem.name}</p>`;
    text += `<p><b>Номер</b>: ${order.number}</p>`;
    text += `<p><b>Качество</b>: ${orderItem.quantity}</p>`;
    text += `<p><b>Материал</b>: ${orderItem.unit}</p>`;
    text += `<p><b>Дата</b>: ${order.date}</p>`;
    let provider = await getProviderById(order.providerId);
    text += `<p><b>Поставщик</b>: ${provider.name}</p>`;
    newDiv.innerHTML = text;
    div.appendChild(newDiv);

    let deleteButton = document.getElementById('delete-order');
    deleteButton.setAttribute('onclick', `deleteOrder(${id}); deleteOrderItem(${orderItem.id})`);

    let editButton = document.getElementById('edit-order');
    editButton.setAttribute('onclick', `goToEditPage(${id})`);
}
