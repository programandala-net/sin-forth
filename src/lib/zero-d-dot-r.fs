\ lib/zero-d-dot-r.fs
\ by Marcos Cruz (programandala.net), 2020, 2023.
\ Last modified: 20230423T1138+0200.

\ This file is part of Sin Forth
\ by Marcos Cruz (programandala.net), 2010/2023.

\ ==============================================================
\ License

\ You may do whatever you want with this work, so long as you
\ retain every copyright, credit and authorship notice, and this
\ license.  There is no warranty.

\ ==============================================================

require d-dot-r.fs \ `d.r`

get-order get-current

target-definitions

: 0d.r ( d -- )
  0 literal d.r ;

  \ doc{
  \
  \ 0d.r ( d -- ) "zero-d-dot-r"
  \
  \ Display _d_ according to current base, with no leading or
  \ trailing spaces.  ``d0.r`` is a faster alternative to the
  \ idiom ``0 d.r``.
  \
  \ See also: `d.r`, `0.r`.
  \
  \ }doc

set-current set-order
