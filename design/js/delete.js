async function deleteOrder(id)
{
    let response = await fetch(`https://localhost:7252/api/Order/${id}`, {
        method: "DELETE",
        headers:  {"accept": "application/json"} 
    });

    if (response.ok === true){
        let order = await response.json();
        let table = document.getElementById('list-orders').getElementsByTagName('tbody')[0].innerHTML = "";
        let orders = await getOrders();
        await pullOrders(orders);
        return order;
    }
    else{
        alert("error");
    }
}

async function deleteOrderItem(id)
{
    let response = await fetch(`https://localhost:7252/api/OrderItem/${id}`, {
        method: "DELETE",
        headers:  {"accept": "application/json"} 
    });

}
