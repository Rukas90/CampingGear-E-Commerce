import EntryThumb from "./EntryThumb"
import EntryContent from "./EntryContent"

const CartItemEntry = () => {
  return (
    <>
      <div className="flex flex-col w-full py-4">
        <div className="relative flex shine">
          <EntryThumb />
          <EntryContent />
        </div>
      </div>
    </>
  )
}
export default CartItemEntry
