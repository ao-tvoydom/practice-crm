import  { createRouter, createWebHashHistory } from 'vue-router'
import Products from "@/pages/products/Products";
import Product from "@/pages/products/Product";
import Shipments from "@/pages/shipments/Shipments";
import Storages from "@/pages/storages/Storages";
import Storage from "@/pages/storages/Storage";
import EditStorage from "@/pages/storages/EditStorage";
import Supplies from "@/pages/supplies/Supplies";
import EditProduct from "@/pages/products/EditProduct";
import CreateProduct from "@/pages/products/CreateProduct";
import CreateStorage from "@/pages/storages/CreateStorage";
import Categories from "@/pages/categories/Categories";
import Category from "@/pages/categories/Category";
import EditCategory from "@/pages/categories/EditCategory";
import CreateCategory from "@/pages/categories/CreateCategory";
import ProductsInStorage from "@/pages/products_in_storage/ProductsInStorage";
import ProductInStorage from "@/pages/products_in_storage/ProductInStorage";
import EditProductInStorage from "@/pages/products_in_storage/EditProductInStorage";
import Login from "@/pages/Login";
import CreateProductInStorage from "@/pages/products_in_storage/CreateProductInStorage";
import EditSupply from "@/pages/supplies/EditSupply";
import Supply from "@/pages/supplies/Supply";
import CreateSupply from "@/pages/supplies/CreateSupply";
import EditShipment from "@/pages/shipments/EditShipment";
import Shipment from "@/pages/shipments/Shipment";
import CreateShipment from "@/pages/shipments/CreateShipment";
import ShipmentContents from "@/pages/shipment_contents/ShipmentContents";
import ShipmentContent from "@/pages/shipment_contents/ShipmentContent";
import EditShipmentContent from "@/pages/shipment_contents/EditShipmentContent";
import CreateShipmentContent from "@/pages/shipment_contents/CreateShipmentContent";


export default createRouter({
    routes: [
        { path: '/', component:  Products },
        { path: '/products', component:  Products },
        { path: '/product/:id', component:  Product },
        { path: '/product/:id/edit', component:  EditProduct },
        { path: '/product', component:  CreateProduct },

        { path: '/categories', component:  Categories },
        { path: '/category/:id', component:  Category },
        { path: '/category/:id/edit', component:  EditCategory },
        { path: '/category', component:  CreateCategory },

        { path: '/products_in_storage', component:  ProductsInStorage },
        { path: '/product_in_storage/:id', component:  ProductInStorage },
        { path: '/product_in_storage/:id/edit', component:  EditProductInStorage },
        { path: '/product_in_storage', component:  CreateProductInStorage },

        { path: '/storages', component:  Storages },
        { path: '/storage/:id', component:  Storage },
        { path: '/storage/:id/edit', component:  EditStorage },
        { path: '/storage', component:  CreateStorage },

        { path: '/shipments', component:  Shipments },
        { path: '/shipment/:id', component:  Shipment },
        { path: '/shipment/:id/edit', component:  EditShipment },
        { path: '/shipment', component:  CreateShipment },

        { path: '/shipment_contents', component:  ShipmentContents },
        { path: '/shipment_content/:id', component:  ShipmentContent },
        { path: '/shipment_content/:id/edit', component:  EditShipmentContent },
        { path: '/shipment_content', component:  CreateShipmentContent },


        { path: '/supplies', component:  Supplies },
        { path: '/supply/:id/edit', component:  EditSupply },
        { path: '/supply/:id', component:  Supply },
        { path: '/supply', component:  CreateSupply },

        { path: '/login', component:  Login }
    ],
    history: createWebHashHistory()
})