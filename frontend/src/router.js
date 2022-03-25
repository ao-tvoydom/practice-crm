import  { createRouter, createWebHashHistory } from 'vue-router'
import Products from "@/pages/Products";
import Shipments from "@/pages/Shipments";
import Storages from "@/pages/Storages";
import Supplies from "@/pages/Supplies";

export default createRouter({
    routes: [
        { path: '/', component:  Products },
        { path: '/shipments', component:  Shipments },
        { path: '/storages', component:  Storages },
        { path: '/supplies', component:  Supplies },
    ],
    history: createWebHashHistory()
})