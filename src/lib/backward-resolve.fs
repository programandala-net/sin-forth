\ lib/backward-resolve.fs
\ by Marcos Cruz (programandala.net), 2020, 2023.
\ Last modified: 20230422T1824+0200.

\ This file is part of Sin Forth
\ by Marcos Cruz (programandala.net), 2010/2023.

\ ==============================================================

get-order get-current

compiler-definitions

: <resolve \ Compilation: ( dest -- )
  memory> @ 2 - t-! ;

  \ doc{
  \
  \ <resolve  Compilation: ( dest -- ) "backward-resolve"
  \
  \ Resolve a backward branch.  Set _set_ as the destination address
  \ of a Z80 ``jp`` instruction just compiled. _dest_ was usually left
  \ on the stack by `<mark`.
  \
  \ See also: `>resolve`.
  \
  \ }doc

set-current set-order
