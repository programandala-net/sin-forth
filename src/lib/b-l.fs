\ lib/b-l.fs
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

require c-constant.fs \ `cconstant`

get-order get-current

target-definitions

32 cconstant bl

  \ doc{
  \
  \ bl ( -- c ) "b-l"
  \
  \ A `cconstant`. _c_ is the character value for a space.
  \
  \ Because space is used throughout Forth as the standard
  \ delimiter, ``bl`` is the only way a program has to find and
  \ use the character value of a space.
  \
  \ See also: `space`, `emit`.
  \
  \ }doc

set-current set-order
