﻿var app = new Vue({
    el: '#app',
    data: {

        status: 0,
        loading: false,
        orders: [],
        selectedOrder: null



    },
    mounted() {
        this.getOrders();
    },
    watch: {
        status: function () {
            this.getOrders();
        }
    },
    methods: {

        getOrders() {
            this.loading = true;
            axios.get('/Admin/orders?status=' + this.status)
                .then(result => {

                    this.orders = result.data;
                    this.loading = false;
                })


        },
        selectOrder(id) {
            this.loading = true;
            axios.get('/Admin/ordersGet/' + id)
                .then(result => {
                    this.selectedOrder = result.data;
                    this.loading = false;
                })
        },

        updateOrder() {
            this.loading = true;
            axios.put('/Admin/ordersUpdate/', + this.selectedOrder.id)
                .then(result => {
                    this.loading = false;
                    this.exitOrder();
                    this.getOrders();
                })

        },

        exitOrder() {
            this.selectedOrder = false;
            
        }
    },
    computed: {
    }

});