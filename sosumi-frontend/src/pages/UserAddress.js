import React, { useState } from "react"
import ChangeAddressWindow from "../components/UserProfile/ChangeAddressWindow"

const UserAddress = (props) => {
    const [editAddress, setEditAddress] = useState(false)

    const editAddressWindow = () => {

    }

    return (
        <div>
            <div>ADDRESS</div>
            <div>YOUR CURRENT ADDRESS IS</div>
            {/* <div>{props.user.address}</div> */}
            <button 
                onClick={
                    () => {
                        const edit = !editAddress
                        setEditAddress(edit)
                        console.log(editAddress)
                    }
                }
                disabled={editAddress}>CHANGE</button>
            { editAddress ? <ChangeAddressWindow edit={editAddress} /> : null }
        </div>
    )
}

export default UserAddress