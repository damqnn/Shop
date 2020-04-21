var app = new Vue({
    el: '#app',
    data: {
        
            editing: false,
            loading: false,
            objectindex: 0,
            productModel: {
                id: 0,
                name: 'Product Name',
                desctription: "Product Description",
                value: 1.99
            },
            products: [],
        

    },
    mounted() {
        this.getProducts();
    },
    methods: {

        getProducts(id) {
            this.loading = true;
            axios.get('/Admin/products/' + id)
                .then(res => {
                    console.log(res);
                    this.products = res.data;
                    this.productModel = {
                        id: product.id,
                        name: product.name,
                        desctription: product.description,
                        value: product.value,
                    }
                })
                .catch(err => {
                    console.log(err);
                })
                .then(() => {
                    this.loading = false;
                });

        },
        getProducts() {
            this.loading = true;
            axios.get('/Admin/productsGet')
                .then(res => {
                    console.log(res);
                    this.products = res.data
                })
                .catch(err => {
                    console.log(err);
                })
                .then(() => {
                    this.loading = false;
                });

        },
        createProduct() {
            this.loading = true;
            this.productModel.value = parseFloat(this.productModel.value)

            axios.post('/Admin/productsCreate', this.productModel)
                .then(res => {
                    this.products.push(res.data)
                    console.log(res);
                })
                .catch(err => {
                    console.log(err);
                })
                .then(() => {
                    this.loading = false;
                    this.editing = false;
                });
        },
        updataProduct() {
            this.loading = true;
            axios.put('/Admin/productsUpdate', this.productModel)
                .then(res => {
                    console.log(res);
                    this.products.splice(this.objectindex, 1, res.data)
                })
                .catch(err => {
                    console.log(err);
                })
                .then(() => {
                    this.loading = false;
                    this.editing = false;
                });
        },
        deleteProducts(id, index) {
            this.loading = true;
            axios.delete('/Admin/productss/' + id)
                .then(res => {
                    console.log(res);
                    this.products.splice(index, 1)
                })
                .catch(err => {
                    console.log(err);
                })
                .then(() => {
                    this.loading = false;
                });

        },
        newProduct() {
            this.editing = true;
            this.productModel.id = 0
        },
        editProduct(id, index) {
            this.objectindex = index;
            this.getProducts(id);
            this.editing = true;
        },
        cancel() {
            this.editing = false;
        }
    },
    computed: {
    }

})