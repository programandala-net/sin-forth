\ lib/two-dup.fs
\ by Marcos Cruz (programandala.net), 2023.
\ Last modified: 20230425T1515+0200.

\ This file is part of Sin Forth
\ by Marcos Cruz (programandala.net), 2010/2023.

\ ==============================================================
\ License

\ You may do whatever you want with this work, so long as you
\ retain every copyright, credit and authorship notice, and this
\ license.  There is no warranty.

\ ==============================================================

require push-hl.fs  \ `push-hl`

: 2dup ( x1 x2 -- x1 x2 x1 x2 )
  0 ix l ftx, \ ld l,(ix+0)
  1 ix h ftx, \ ld h,(ix+1)
  push-hl     \ call push_hl
  push-hl ;   \ jp push_hl

  \ doc{
  \
  \ 2dup ( x1 x2 -- x1 x2 x1 x2 )
  \
  \ Duplicate the cell pair _x1 x2_.
  \
  \ // XXX TODO
  \ // See also: `dup`, `2over`, `2drop`, `3dup`, `4dup`.
  \ See also: `dup`.
  \
  \ }doc
