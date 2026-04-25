import { useEffect, useState } from 'react'
import axios from 'axios'
import 'bootstrap/dist/css/bootstrap.min.css'
import './App.css'

function App() {
    const [products, setProducts] = useState([])
    const [form, setForm] = useState({
        name: '',
        price: '',
        color: ''
    })

    const baseUrl = 'https://localhost:7122/api'

    const getToken = async () => {
        const res = await axios.get(`${baseUrl}/jwt/token`)
        localStorage.setItem('token', res.data.token)
        return res.data.token
    }

    const getAuthHeader = async () => {
        let token = localStorage.getItem('token')
        if (!token) token = await getToken()

        return {
            headers: {
                Authorization: `Bearer ${token}`
            }
        }
    }

    const loadProducts = async () => {
        try {
            const config = await getAuthHeader()
            const res = await axios.get(`${baseUrl}/products?page=1&pageSize=20`, config)

            console.log('products response:', res.data)

            setProducts(res.data) 
        }
        catch (err)
        {
            if (err.response?.status === 401) {
                localStorage.removeItem('token')
                return loadProducts()
            }
            console.error('Load error:', err)
        }
    }

    const handleSubmit = async (e) => {
        e.preventDefault()

        try {
            const config = await getAuthHeader()

            await axios.post(`${baseUrl}/products`, {
                name: form.name,
                price: Number(form.price),
                color: form.color
            }, config)

            setForm({ name: '', price: '', color: '' })
            loadProducts()
        } catch (err) {
            console.error('Create error:', err)
        }
    }

    useEffect(() => {
        loadProducts()
    }, [])

    return (
        <div className="container py-5">
            <div className="row g-4">

                <div className="col-lg-4">
                    <div className="card shadow-sm">
                        <div className="card-header bg-dark text-white">
                            Add Product
                        </div>
                        <div className="card-body">
                            <form onSubmit={handleSubmit}>
                                <div className="mb-3">
                                    <input
                                        className="form-control"
                                        placeholder="Name"
                                        value={form.name}
                                        onChange={(e) => setForm({ ...form, name: e.target.value })}
                                        required
                                    />
                                </div>

                                <div className="mb-3">
                                    <input
                                        type="number"
                                        className="form-control"
                                        placeholder="Price"
                                        value={form.price}
                                        onChange={(e) => setForm({ ...form, price: e.target.value })}
                                        required
                                    />
                                </div>

                                <div className="mb-3">
                                    <input
                                        className="form-control"
                                        placeholder="Color"
                                        value={form.color}
                                        onChange={(e) => setForm({ ...form, color: e.target.value })}
                                        required
                                    />
                                </div>

                                <button className="btn btn-primary w-100">
                                    Save
                                </button>
                            </form>
                        </div>
                    </div>
                </div>

                <div className="col-lg-8">
                    <div className="card shadow-sm">
                        <div className="card-header bg-secondary text-white">
                            Products
                        </div>
                        <div className="card-body p-0">
                            <table className="table mb-0 table-striped">
                                <thead className="table-light">
                                    <tr>
                                        <th>Name</th>
                                        <th>Price</th>
                                        <th>Color</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    {products.length === 0 && (
                                        <tr>
                                            <td colSpan="3" className="text-center py-4">
                                                No products yet
                                            </td>
                                        </tr>
                                    )}

                                    {products.map((p, i) => (
                                        <tr key={i}>
                                            <td>{p.name}</td>
                                            <td>{p.price}</td>
                                            <td>{p.color}</td>
                                        </tr>
                                    ))}
                                </tbody>
                            </table>
                        </div>
                    </div>
                </div>

            </div>
        </div>
    )
}

export default App