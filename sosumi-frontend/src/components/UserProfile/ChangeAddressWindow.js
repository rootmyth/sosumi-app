import React, { useState }from "react"

const ChangeAddressWindow = (props) => {
    const [editAddress, setEditAddress] = useState(props.edit)

    const sendEditStateBoolToPage = (edit) => {
        setEditAddress(edit)
    }

    return (
        <form>
            <label htmlFor="address">WHAT WOULD YOU LIKE YOUR NEW ADDRESS TO BE?</label>
            <input type="text" id="address" name="address"></input>
            <input type="submit" value="Save" onclick={() => sendEditStateBoolToPage(editAddress)}></input>
        </form>
    )
}

export default ChangeAddressWindow