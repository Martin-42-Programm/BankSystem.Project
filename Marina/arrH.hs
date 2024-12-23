


customSplit :: String -> [String]
customSplit [] = []
customSplit (x:xs) =
    -- if x == delimiter
    --     then customSplit xs delimiter
        [x] : customSplit xs         

customMerge :: [String]-> String->[String]
customMerge [] _= []
customMerge [x] _ = [x]
customMerge (x:(y:xs)) delimiter =
    if y /= delimiter
        then customMerge ((x++y):xs) delimiter
        else [x] ++ customMerge xs delimiter


customToList str delimiter = customMerge (customSplit str) delimiter


customCategories [] = []
customCategories (x:xs) = [x] ++ customCategories (filter (/= x) xs) 

catgCount :: [String] -> [Int] -> [String] -> [Int]
catgCount [] listCount _ = listCount
catgCount (x:xs) listCount listInit= catgCount xs (listCount ++ [length (filter (== x) listInit)]) listInit

customMap [] _ = []
customMap (x:xs) func = [func x] ++ customMap xs func

intToDouble :: Int -> Double
intToDouble n = read (show n) :: Double


catgPercent :: Foldable t => [Double] -> t a -> [Double]
catgPercent list listInit = do
    let n = intToDouble (length listInit)
    customMap list ( / n )
    



printFormatedLine :: (Show a1, Show a2) => [([Char], a1, a2)] -> IO ()
printFormatedLine [] = return ()
printFormatedLine ((x, y, z):xs) = do
    putStrLn $ (x) ++ " -> " ++ (show y) ++ " times (" ++ (show z) ++ "%)"
    printFormatedLine xs


roundToTwoDecimalPlaces :: Double -> Double
roundToTwoDecimalPlaces x = fromIntegral (round (x * 100)) / 100


makeTriples :: [a] -> [b] -> [Double] -> [(a, b, Double)]
makeTriples [] [] [] = []
makeTriples (category:categories) (count:counts) (percent:percents) =
    [(category, count, (roundToTwoDecimalPlaces (percent * 100)) )] ++ makeTriples categories counts percents


customContains :: Eq t => [t] -> t -> Bool
customContains [] _ = False
customContains (x:xs) element = 
    (x == element) || customContains xs element

getIndexOfInternal (y:ys) x index
    | y == x = index
    | otherwise = getIndexOfInternal ys x (index + 1)


getIndexOf list x
    | customContains list x = getIndexOfInternal list x 0
    | otherwise = -1


sortArr :: Ord a => [a] -> [a]
sortArr [] = []
sortArr [x] = [x]
sortArr (x:(y:xs))
    | x < y = (y : sortArr (x:xs))
    |otherwise = (x: sortArr(y:xs))

customSort :: Ord a => [a] -> [a]
customSort list = do 
    let sortedList = sortArr list
    if list == sortedList
        then list
        else customSort sortedList

-- Sorting function that compares the second element (y) of each triple


sortTriples :: Ord c => [(a, b, c)] -> [(a, b, c)]
sortTriples [] = []  -- Empty list is already sorted
sortTriples [x] = [x]  -- A single element list is already sorted
sortTriples ((x1, y1, z1) : (x, y, z):xs)
    | z1 < z     = (x, y, z) : sortTriples ((x1, y1, z1):xs)  -- Swap the elements if z1 > z
    | otherwise  = (x1, y1, z1) : sortTriples ((x, y, z):xs)  -- No swap, continue sorting




customSortTrip :: (Ord c, Eq a, Eq b) => [(a, b, c)] -> [(a, b, c)]
customSortTrip triples = do
    let sortedTrips = sortTriples triples
    if triples == sortedTrips
        then sortedTrips
        else customSortTrip sortedTrips

main = do
    input <- getLine
    let listInit =  customToList input " "
    let catgs = customCategories listInit
    let catgsCount = catgCount catgs [] listInit
    let catgsCountDoubles = customMap catgsCount intToDouble
    let catgsPercents = catgPercent catgsCountDoubles listInit
    let trips = makeTriples catgs catgsCount catgsPercents
   

    printFormatedLine (customSortTrip trips)
    


