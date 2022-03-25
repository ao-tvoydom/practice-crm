import  { createRouter, createWebHashHistory } from 'vue-router'
import Products from "@/pages/products/Products";
import Product from "@/pages/products/Product";
import Shipments from "@/pages/Shipments";
import Storages from "@/pages/Storages";
import Supplies from "@/pages/Supplies";
import EditProduct from "@/pages/products/EditProduct";

export default createRouter({
    routes: [
        { path: '/', component:  Products },
        { path: '/product/:id', component:  Product },
        { path: '/product/:id/edit', component:  EditProduct },


        { path: '/shipments', component:  Shipments },
        { path: '/storages', component:  Storages },
        { path: '/supplies', component:  Supplies },
    ],
    history: createWebHashHistory()
})