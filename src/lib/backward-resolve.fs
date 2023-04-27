\ lib/backward-resolve.fs
\ by Marcos Cruz (programandala.net), 2020, 2023.
\ Last modified: 20230426T1307+0200.

\ This file is part of Sin Forth
\ by Marcos Cruz (programandala.net), 2010/2023.

\ ==============================================================
\ License

\ You may do whatever you want with this work, so long as you
\ retain every copyright, credit and authorship notice, and this
\ license.  There is no warranty.

\ ==============================================================

get-order get-current

compiler-definitions

: <resolve \ Compilation: ( dest -- )
  t-here t-cell - t-! ;

  \ doc{
  \
  \ <resolve  Compilation: ( dest -- ) "backward-resolve"
  \
  \ Resolve a backward branch.  Set _set_ as the destination address
  \ of a Z80 ``jp`` instruction just compiled. _dest_ was usually left
  \ on the stack by `<mark`.
  \
  \ See also: `>resolve`, `t-here`.
  \
  \ }doc

set-current set-order
