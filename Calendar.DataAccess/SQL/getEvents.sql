CREATE OR REPLACE FUNCTION get_all_event_ordered_by_id()
RETURNS SETOF "Events"
AS $$
BEGIN
    RETURN QUERY
        SELECT * 
        FROM "Events"
        ORDER BY id;
END;
$$ LANGUAGE plpgsql;
