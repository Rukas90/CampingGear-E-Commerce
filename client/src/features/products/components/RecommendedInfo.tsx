interface RecommendedInfoProps {
  count: number
  total: number
}
const RecommendedInfo = ({ count, total }: RecommendedInfoProps) => {
  const percentage = total > 0 ? Math.round((count / total) * 100) : 0

  return (
    <div className="relative flex gap-2.5 items-center mt-2">
      <span className="text-xl">{percentage}%</span>{" "}
      <div className="w-px h-6 bg-stone-400" />
      <span>
        {count} of {total} reviewers recommended
      </span>
    </div>
  )
}
export default RecommendedInfo
