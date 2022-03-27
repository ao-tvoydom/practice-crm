import  { createRouter, createWebHashHistory } from 'vue-router'
import Products from "@/pages/products/Products";
import Product from "@/pages/products/Product";
import Shipments from "@/pages/Shipments";
import Storages from "@/pages/storages/Storages";
import Storage from "@/pages/storages/Storage";
import EditStorage from "@/pages/storages/EditStorage";
import Supplies from "@/pages/Supplies";
import EditProduct from "@/pages/products/EditProduct";
import CreateProduct from "@/pages/products/CreateProduct";
import CreateStorage from "@/pages/storages/CreateStorage";

export default createRouter({
    routes: [
        { path: '/', component:  Products },
        { path: '/products', component:  Products },
        { path: '/product/:id', component:  Product },
        { path: '/product/:id/edit', component:  EditProduct },
        { path: '/product', component:  CreateProduct },

        { path: '/storages', component:  Storages },
        { path: '/storage/:id', component:  Storage },
        { path: '/storage/:id/edit', component:  EditStorage },
        { path: '/storage', component:  CreateStorage },

        { path: '/shipments', component:  Shipments },
        { path: '/storages', component:  Storages },
        { path: '/supplies', component:  Supplies },
    ],
    history: createWebHashHistory()
})